SELECT * FROM [core].[Atoms]
select * from [core].[DirectProfiles]

select date,ProfileId,DeviceTypeId, CampaignId from [core].[DirectDataRaw]
where ProfileId=3 and Date between cast('2019-02-01' as Date) and cast('2019-02-05' as Date)
	and DeviceTypeId=1 and CampaignId=36403386

update [core].[DirectDataRaw] set CampaignId=100600
where ProfileId=3 and Date between cast('2019-02-01' as Date) and cast('2019-02-05' as Date)
	and DeviceTypeId=1 and CampaignId=36403386

declare
	@st date = cast('2019-02-01' as Date)
	,@en date = cast('2019-02-28' as Date)

select * from [core].[DirectGetMissingCampaigns](@st, @en)



ALTER FUNCTION [core].[DirectGetMissingCampaigns](@fromDate datetime, @toDate datetime)
RETURNS TABLE 
AS
RETURN 
(
	SELECT		1					AS [AdEngineId],
				P.[Id]				AS [ProfileId], 
				P.[ClientName]		AS [ProfileName],
				DR.[CampaignId], 
				DR.[CampaignName],
				SUM(DR.[Shows])		AS [Shows],
				SUM(DR.[Clicks])	AS [Clicks],
				SUM(DR.[BudgetWithCommissions])
									AS [Budget],
				MIN(DR.[Date])		AS [MinDate],
				MAX(DR.[Date])		AS [MaxDate]
	FROM		[core].[DirectDataRaw]		AS DR
	LEFT JOIN	[core].[AdEngineCampaigns]	AS C	ON  DR.[CampaignId] = C.[CampaignId] AND C.[AdEngineId] = 1
	LEFT JOIN	[core].[DirectProfiles]		AS P	ON  DR.[ProfileId] = P.[Id]
	LEFT JOIN	[core].[Atoms]				AS A	ON  A.[Id] = C.[AtomId] 
		AND A.[Version] = C.[Version] 
		AND	DR.[Date] >= A.[StartDate] AND (DR.[Date] <= A.[EndDate] OR A.[EndDate] IS NULL) 
		AND	A.[IsEnabled] = 1
	WHERE		DR.[Date] >= @fromDate AND DR.[Date] <= @toDate AND A.[Id] IS NULL

AND DR.[Date] >= P.[DateBegin] AND DR.[Date] <= P.[DateEnd] 
AND P.[Inactive]=0

				AND DR.[CampaignId] NOT IN 
					(
						SELECT		DISTINCT DR.[CampaignId]
						FROM		[core].[DirectDataRaw]		AS DR
						LEFT JOIN	[core].[AdEngineCampaigns]	AS C	ON  DR.[CampaignId] = C.[CampaignId] AND C.[AdEngineId] = 1
						LEFT JOIN	[core].[Atoms]				AS A	ON  A.[Id] = C.[AtomId] AND 
																			A.[Version] = C.[Version] AND
																			DR.[Date] >= A.[StartDate] AND (DR.[Date] <= A.[EndDate] OR A.[EndDate] IS NULL) AND
																			A.[IsEnabled] = 1
						WHERE		DR.[Date] >= @fromDate AND DR.[Date] <= @toDate AND A.[Id] IS NOT NULL
					)
	GROUP BY	P.[Id], P.[ClientName], DR.[CampaignId], DR.[CampaignName]
)




declare
	@st date = cast('2019-02-01' as Date)
	,@en date = cast('2019-02-28' as Date)

select * from [core].[DirectDataRawCheckCampaignsForMapping](@st, @en)

declare
	@st date = cast('2019-02-01' as Date)
	,@en date = cast('2019-02-28' as Date)

select * from [core].[DirectDataRawCheckAtomCountForMapping](@st, @en)


ALTER FUNCTION [core].[DirectDataRawCheckAtomCountForMapping](@fromDate datetime, @toDate datetime)
RETURNS TABLE 
AS
RETURN 
(
	WITH atoms AS
	(
			SELECT		P.[Id]				AS [ProfileId], 
						P.[ClientName],
						Dr.[CampaignId], 
						Dr.[CampaignName],
						Dr.[Date],
						A.[Id]				AS [AtomId],
						A.[Version]
			FROM		[core].[DirectDataRaw]		AS Dr
			LEFT JOIN	[core].[AdEngineCampaigns]	AS Aec	ON	Dr.[CampaignId] = Aec.[CampaignId] AND Aec.[AdEngineId] = 1
			LEFT JOIN	[core].[DirectProfiles]		AS P	ON  Dr.[ProfileId] = P.[Id]
			LEFT JOIN	[core].[Atoms]				AS A	ON  A.[Id] = Aec.[AtomId] AND 
																A.[Version] = Aec.[Version] AND
																A.[IsEnabled] = 1 AND
																Dr.[Date] >= A.[StartDate] AND (Dr.[Date] <= A.[EndDate] OR A.[EndDate] IS NULL)
			WHERE	1=1	
				--and Dr.[Date] >= @fromDate AND Dr.[Date] <= @toDate AND A.[Id] IS NOT NULL AND A.[Version] IS NOT NULL

AND Dr.[Date] >= P.[DateBegin] AND Dr.[Date] <= P.[DateEnd] 
AND P.[Inactive]=0

			GROUP BY	P.[Id], P.[ClientName], Dr.[CampaignId], Dr.[CampaignName], Dr.[Date], A.[Id], A.[Version]
	)
	SELECT DISTINCT  
			[ProfileId], 
			[ClientName],
			[CampaignId], 
			[CampaignName], 
			[AtomId],
			[Version]
	FROM	atoms 
	WHERE	[CampaignId] IN	(
								SELECT		[CampaignId] 
								FROM		atoms 
								GROUP BY	[CampaignId], [Date]
								HAVING		COUNT(*) =1  
							)
)




ALTER FUNCTION [core].[DirectDataRawCheckCampaignsForMapping](@fromDate datetime, @toDate datetime)
RETURNS TABLE 
AS
RETURN 
(
	WITH atoms AS (
		SELECT	Dp.[Id]				AS [ProfileId], 
				Dp.[ClientName],
				Ddr.[CampaignId], 
				Ddr.[CampaignName],
				A.[Id]				AS [Atom],
				Adef.[Id]			AS [DefaultAtom]
		FROM [core].[DirectDataRaw] AS Ddr
		LEFT JOIN [core].[AdEngineCampaigns]	AS Aec	ON  Ddr.[CampaignId] = Aec.[CampaignId] AND [AdEngineId] = 1
		LEFT JOIN [core].[DirectProfiles]		AS Dp	ON  Ddr.[ProfileId] = Dp.[Id]
		LEFT JOIN [core].[Atoms]				AS A	ON  A.[Id] = Aec.[AtomId] AND 
			A.[Version] = Aec.[Version] 
			AND	Ddr.[Date] >= A.[StartDate] 
			AND (Ddr.[Date] <= A.[EndDate] OR A.[EndDate] IS NULL) 
			AND	A.[IsEnabled] = 1
		LEFT JOIN [core].[Atoms]				AS Adef ON  Adef.[Id] = Dp.[OwnerlessAtomId] 
			AND Adef.[Version] = Dp.[OwnerlessVersion] 
			AND	Ddr.[Date] >= Adef.[StartDate] 
			AND (Ddr.[Date] <= Adef.[EndDate] OR Adef.[EndDate] IS NULL) 
			AND Adef.[IsEnabled] = 1
		WHERE 1=1
			and Ddr.[Date] >= @fromDate AND Ddr.[Date] <= @toDate
AND Ddr.[Date] >= Dp.[DateBegin] AND Ddr.[Date] <= Dp.[DateEnd] 
AND Dp.[Inactive]=0

		GROUP BY Dp.[Id], Dp.[ClientName], Ddr.[CampaignId], Ddr.[CampaignName], A.[Id], Adef.[Id]
	)
	SELECT  [ProfileId], 
			[ClientName],
			[CampaignId], 
			[CampaignName],
			[Atom],
			[DefaultAtom]
	FROM atoms
	WHERE [Atom] IS NULL AND [DefaultAtom] IS NULL AND [CampaignId] NOT IN (
		SELECT DISTINCT [CampaignId] 
		FROM atoms 
		WHERE [Atom] IS NOT NULL 
	)
)