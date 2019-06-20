/****** Object:  View [pivotparts].[Crm2]    Script Date: 21.06.2019 7:30:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [pivotparts].[Crm2]
AS
SELECT t1.[Date], t1.[AtomId], t1.[Version], 
	SUM(t1.[�������]) AS [�������],
	SUM(t1.[���������� �������������]) AS [���������� �������������],
	SUM(t1.[���������� �������]) AS [���������� �������],
	SUM(t1.[��������� �������������]) AS [��������� �������������],
	SUM(t1.[��������� �������]) AS [��������� �������],
	SUM(t1.[����� �������������]) AS [����� �������������],
	SUM(t1.[�� �������� �������������]) AS [�� �������� �������������],
	SUM(t1.[������ �������������]) AS [������ �������������],
	SUM(t1.[�������� ��������� �������������]) AS [�������� ��������� �������������],
	SUM(t1.[����� �������� �������������]) AS [����� �������� �������������],
	SUM(t1.[����� �������]) AS [����� �������],
	SUM(t1.[�� �������� �������]) AS [�� �������� �������],
	SUM(t1.[������ �������]) AS [������ �������],
	SUM(t1.[�������� ��������� �������]) AS [�������� ��������� �������],
	SUM(t1.[����� �������� �������]) AS [����� �������� �������],
	SUM(t1.[����� �� ���� ���������]) AS [����� �� ���� ���������],
	SUM(t1.[�� �������� �� ���� ���������]) AS [�� �������� �� ���� ���������],
	SUM(t1.[������ �� ���� ���������]) AS [������ �� ���� ���������],
	SUM(t1.[�������� �� ���� ���������]) AS [�������� �� ���� ���������],
	SUM(t1.[����� �������� �� ���� ���������]) AS [����� �������� �� ���� ���������],
	SUM(t1.[��������� �������� �������������]) AS [��������� �������� �������������],
	SUM(t1.[��������� �������� �������������]) AS [��������� �������� �������������],
	SUM(t1.[��������� �� ���������� �������������]) AS [��������� �� ���������� �������������],
	SUM(t1.[��������� ���������� �������������]) AS [��������� ���������� �������������],
	SUM(t1.[��������� �������� �������]) AS [��������� �������� �������],
	SUM(t1.[���������� �������� �������]) AS [���������� �������� �������],
	SUM(t1.[��������� �� ���������� �������]) AS [��������� �� ���������� �������],
	SUM(t1.[���������� ���������� �������]) AS [���������� ���������� �������],
	SUM(t1.[��������� �������� �� ���� ���������]) AS [��������� �������� �� ���� ���������],
	SUM(t1.[���������� �������� �� ���� ���������]) AS [���������� �������� �� ���� ���������],
	SUM(t1.[��������� �� ���������� �� ���� ���������]) AS [��������� �� ���������� �� ���� ���������],
	SUM(t1.[���������� ���������� �� ���� ���������]) AS [���������� ���������� �� ���� ���������]
FROM (
-- ������� 
SELECT	[AtomId], [Version], CAST([CreateDate] AS DATE) AS [Date],
	COUNT(*) AS [�������],
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [��������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
FROM [client].[CrmResumeDaxtra]
GROUP BY [AtomId], [Version], CAST([CreateDate] AS DATE)

UNION ALL
 
-- ���������� �������������
SELECT ISNULL(R.[AtomId], 3200) AS [AtomId], ISNULL(R.[Version], 1) AS [Version], CAST(R.[CreateDate] AS DATE) AS [Date], 
	0 AS [�������], 
	COUNT(*) AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [��������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
FROM [client].[CrmPartners] AS P
LEFT JOIN [client].[CrmResumeDaxtra] AS R ON P.[Id] = R.[PartnerId]
GROUP BY R.[AtomId], R.[Version], CAST(R.[CreateDate] AS DATE)

UNION ALL

-- ���������� �������
SELECT ISNULL(R.[AtomId], 3200) AS [AtomId], ISNULL(R.[Version], 1) AS [Version], CAST(P.[CreateDate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	COUNT(*) AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [��������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
FROM [client].[CrmPartners] AS P
LEFT JOIN [client].[CrmResumeDaxtra] AS R ON P.[Id] = R.[PartnerId]
GROUP BY R.[AtomId], R.[Version], CAST(P.[CreateDate] AS DATE)

UNION ALL

-- ��������� �������������
SELECT
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date], 
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	COUNT(*) AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [��������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
FROM [client].[CrmApplicants] AS A
LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
LEFT JOIN [client].[CrmResumeDaxtra] AS RD ON RD.[PartnerId] = P.[Id]
GROUP BY CASE WHEN P.[Id] IS NULL THEN 3200
			  WHEN RD.[PartnerId] IS NULL THEN 3300
			  ELSE RD.[AtomId]
		 END,
		 CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
			  ELSE RD.[Version]
		 END, 
		 CAST(RD.[CreateDate] AS DATE)
UNION ALL

-- ��������� ������� �� ����� �������
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date], 
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	COUNT(*) AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [��������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
FROM [client].[CrmApplicants] AS A
LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
LEFT JOIN [client].[CrmResumeDaxtra] AS RD ON RD.[PartnerId] = P.[Id]
GROUP BY CASE WHEN P.[Id] IS NULL THEN 3200
			  WHEN RD.[PartnerId] IS NULL THEN 3300
			  ELSE RD.[AtomId]
		 END, 
		 CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
			  ELSE RD.[Version]
		 END, 
		CAST(A.[CreateDate] AS DATE)


--UNION ALL

-- ��������� �������
--SELECT [AtomId] AS [AtomId], [Version] AS [Version], CAST([CreateDate] AS DATE) AS [Date],
	--0 AS [�������], 
	--0 AS [���������� �������������],
	--0 AS [���������� �������],
	--0 AS [��������� �������������],
	--COUNT(*) AS [��������� �������],
	--0 AS [����� �������������],
	--0 AS [�� �������� �������������],
	--0 AS [������ �������������],
	--0 AS [�������� ��������� �������������],
	--0 AS [����� �������� �������������],
	--0 AS [����� �������],
	--0 AS [�� �������� �������],
	--0 AS [������ �������],
	--0 AS [�������� ��������� �������],
	--0 AS [����� �������� �������],
	--0 AS [��������� �������� �������������],
	--0 AS [��������� �������� �������������],
	--0 AS [��������� �� ���������� �������������],
	--0 AS [��������� ���������� �������������],
	--0 AS [��������� �������� �������],
	--0 AS [���������� �������� �������],
	--0 AS [��������� �� ���������� �������],
	--0 AS [���������� ���������� �������]
--FROM [client].[CrmApplicants]
--GROUP BY [AtomId], [Version], CAST([CreateDate] AS DATE)
	
UNION ALL

-- ����� ��������������� �������������
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [����� �������������],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [�� �������� �������������],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [������ �������������],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [�������� ��������� �������������],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [���������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [���������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
	FROM [client].[CrmApplicants] AS A
	LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
	LEFT JOIN [client].[CrmResumeDaxtra] AS RD ON RD.[PartnerId] = P.[Id]
	GROUP BY 
		CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
		END,
		CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
		END,
	CAST(RD.[CreateDate] AS DATE)

UNION ALL

-- ����� ��������������� �������������
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	SUM(CASE WHEN L.[ActivityId] in (532, 719) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [��������� �������� �������������],
	SUM(CASE WHEN L.[ActivityId] in (595, 721) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [���������� �������� �������������],
	SUM(CASE WHEN L.[ActivityId] in (524, 722) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [��������� �� ���������� �������������],
	SUM(CASE WHEN L.[ActivityId] in (598, 724) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [���������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
	FROM [client].[CrmApplicants] AS A
	LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
	LEFT JOIN [client].[CrmResumeDaxtra] AS RD ON RD.[PartnerId] = P.[Id]
	INNER JOIN [client].[CrmLog] AS L ON L.[ApplicantId] =  A.[Id]
	GROUP BY 
		CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
		END,
		CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
		END,
		CAST(RD.[CreateDate] AS DATE)

UNION ALL

-- ����� � ����� ��������������� �������	
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[DateLastStageUpdate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [����� �������],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [�� �������� �������],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [������ �������],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [�������� ��������� �������],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [������ �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [���������� �������� �������������],
	SUM(CASE WHEN A.[StageId] in (642, 909) THEN 1 ELSE 0 END) AS [��������� �������� �������],
	SUM(CASE WHEN A.[StageId] = 739 THEN 1 ELSE 0 END) AS [���������� �������� �������],
	SUM(CASE WHEN A.[StageId] in (638, 910) THEN 1 ELSE 0 END) AS [��������� �� ���������� �������],
	SUM(CASE WHEN A.[StageId] = 743 THEN 1 ELSE 0 END) AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
	FROM [client].[CrmApplicants] AS A
	LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
	LEFT JOIN
	(
		SELECT * FROM 
			(
				SELECT [PartnerId]
					  ,[CreateDate]
					  ,[AtomId]
					  ,[Version]
					  ,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate] DESC) AS RowNum
				FROM [client].[CrmResumeDaxtra]
			) AS s
		WHERE RowNum = 1
	) AS RD ON RD.[PartnerId] = P.[Id]
	GROUP BY 
			CASE WHEN P.[Id] IS NULL THEN 3200
				   WHEN RD.[PartnerId] IS NULL THEN 3300
				   ELSE RD.[AtomId]
			 END, 
			 CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
				  ELSE RD.[Version]
			 END, 
			CAST(A.[DateLastStageUpdate] AS DATE)

UNION ALL

-- ����� ��������������� �� ���� ���������	
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [����� �� ���� ���������],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [�� �������� �� ���� ���������],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [������ �� ���� ���������],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [�������� �� ���� ���������],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [������ �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [���������� �������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	0 AS [��������� �������� �� ���� ���������],
	0 AS [���������� �������� �� ���� ���������],
	0 AS [��������� �� ���������� �� ���� ���������],
	0 AS [���������� ���������� �� ���� ���������]
	FROM [client].[CrmApplicants] AS A
	LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
	LEFT JOIN
	(
		SELECT * FROM 
			(
				SELECT [PartnerId]
					  ,[CreateDate]
					  ,[AtomId]
					  ,[Version]
					  ,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate] DESC) AS RowNum
				FROM [client].[CrmResumeDaxtra]
			) AS s
		WHERE RowNum = 1
	) AS RD ON RD.[PartnerId] = P.[Id]
	GROUP BY 
		CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
		END,
		CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
		END, 
		CAST(A.[CreateDate] AS DATE)

UNION ALL

-- ����� ��������������� �� ���� ���������
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date],
	0 AS [�������], 
	0 AS [���������� �������������],
	0 AS [���������� �������],
	0 AS [��������� �������������],
	0 AS [��������� �������],
	0 AS [����� �������������],
	0 AS [�� �������� �������������],
	0 AS [������ �������������],
	0 AS [�������� ��������� �������������],
	0 AS [����� �������� �������������],
	0 AS [����� �������],
	0 AS [�� �������� �������],
	0 AS [������ �������],
	0 AS [�������� ��������� �������],
	0 AS [����� �������� �������],
	0 AS [����� �� ���� ���������],
	0 AS [�� �������� �� ���� ���������],
	0 AS [������ �� ���� ���������],
	0 AS [�������� �� ���� ���������],
	0 AS [����� �������� �� ���� ���������],
	0 AS [��������� �������� �������������],
	0 AS [���������� �������� �������������],
	0 AS [��������� �� ���������� �������������],
	0 AS [���������� ���������� �������������],
	0 AS [��������� �������� �������],
	0 AS [���������� �������� �������],
	0 AS [��������� �� ���������� �������],
	0 AS [���������� ���������� �������],
	SUM(CASE WHEN L.[ActivityId] in (532, 719) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [��������� �������� �� ���� ���������],
	SUM(CASE WHEN L.[ActivityId] in (595, 721) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [���������� �������� �� ���� ���������],
	SUM(CASE WHEN L.[ActivityId] in (524, 722) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [��������� �� ���������� �� ���� ���������],
	SUM(CASE WHEN L.[ActivityId] in (598, 724) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [���������� ���������� �� ���� ���������]
	FROM [client].[CrmApplicants] AS A
	LEFT JOIN [client].[CrmPartners] AS P ON A.[PartnerId] = P.[Id]
	LEFT JOIN
	(
		SELECT * FROM 
			(
				SELECT [PartnerId]
					  ,[CreateDate]
					  ,[AtomId]
					  ,[Version]
					  ,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate] DESC) AS RowNum
				FROM [client].[CrmResumeDaxtra]
			) AS s
		WHERE RowNum = 1
	) AS RD ON RD.[PartnerId] = P.[Id]
	LEFT OUTER JOIN [client].[CrmLog] AS L ON L.[ApplicantId] =  A.[Id]
	GROUP BY 
		CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
		END,
		CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
		END, CAST(A.[CreateDate] AS DATE)
) AS t1
GROUP BY t1.[Date], t1.[AtomId], t1.[Version]
GO
























/****** Object:  View [pivotparts].[IbsToClients]    Script Date: 21.06.2019 7:30:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [pivotparts].[IbsToClients]
AS
--������ ��������� ��� ����������� ����������
WITH FirstApplicants
AS
(
	SELECT * 
	FROM	(
			SELECT *
					,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate]) AS [RowNum] 
			from [client].[CrmApplicants]
			) AS A
	WHERE [RowNum] = 1
)
--���� ����� � ������� ����������
,StartDateApplicants
AS
(
	SELECT  FA.[Id], 
			FA.[PartnerId],
			CASE WHEN MIN(CAST(L.[CreateDate] AS DATE)) IS NULL THEN P.[CreateDate]
				 ELSE MIN(CAST(L.[CreateDate] AS DATE)) END 
			AS [CreateDate]
	FROM FirstApplicants AS FA
	LEFT JOIN [client].[CrmLog]			AS L ON FA.[Id] = L.[ApplicantId] AND L.[State] <> 'cancel' 
	LEFT JOIN [client].[CrmPartners]	AS P ON FA.[PartnerId] = P.[Id]
	GROUP BY FA.[Id], FA.[PartnerId], P.[CreateDate]
)
--��������� ��������� ��� ����������� ����������
,LastApplicants
AS
(
	SELECT * 
	FROM	(
			SELECT *
					,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate] DESC) AS [RowNum] 
			from [client].[CrmApplicants]
			) AS A
	WHERE [RowNum] = 1 
)
--����� �����������
,PartnersAtoms
AS
(
	SELECT P.[Id], COALESCE(D.[AtomId], 3200) AS [AtomId], COALESCE(D.[Version], 1) AS [Version]
	FROM [client].[CrmPartners] AS P
	LEFT JOIN 	(
					SELECT [PartnerId], [AtomId] ,[Version], [CreateDate]
							,ROW_NUMBER() OVER (PARTITION BY [PartnerId] ORDER BY [CreateDate]) AS [RowNum] 
					from [client].[CrmResumeDaxtra]
				) AS D ON D.[PartnerId] = P.[Id]
	WHERE ([RowNum] = 1 AND [PartnerId] is not null) OR [PartnerId] is null
	--SELECT P.[Id], D.[AtomId], D.[Version]
	--FROM [client].[CrmPartners] AS P
	--LEFT JOIN [client].[CrmResumeDaxtra] AS D ON D.[PartnerId] = P.[Id]
)
SELECT   CAST([Date] AS DATETIME) AS [����]
		,[AtomId]
		,[Version]
		,SUM([����� �� ���� ����� � �������]) 
		  AS [����� �� ���� ����� � �������]
		,SUM([����� �� ���� ��������]) 
		  AS [����� �� ���� ��������]
		,SUM([�� �������� �� ���� ����� � �������]) 
		  AS [�� �������� �� ���� ����� � �������]
		,SUM([�� �������� �� ���� ��������]) 
		  AS [�� �������� �� ���� ��������]
		,SUM([������ �� ���� ����� � �������]) 
		  AS [������ �� ���� ����� � �������]
		,SUM([������ �� ���� ��������]) 
		  AS [������ �� ���� ��������]
		,SUM([�������� ��������� �� ���� ����� � �������]) 
		  AS [�������� ��������� �� ���� ����� � �������]
		,SUM([�������� ��������� �� ���� ��������]) 
		  AS [�������� ��������� �� ���� ��������]
		,SUM([����� �������� �� ���� ����� � �������]) 
		  AS [����� �������� �� ���� ����� � �������]
		,SUM([����� �������� �� ���� ��������]) 
		  AS [����� �������� �� ���� ��������]
		,SUM([���������� �� �������� �� ���� ����� � �������]) 
		  AS [���������� �� �������� �� ���� ����� � �������]
		,SUM([���������� �� �������� �� ���� ����� � �������]) 
		  AS [���������� �� �������� �� ���� ��������]
		,SUM([���������� �������� �� ���� ����� � �������]) 
		  AS [���������� �������� �� ���� ����� � �������]
		,SUM([���������� �������� �� ���� ��������]) 
		  AS [���������� �������� �� ���� ��������]
		,SUM([�������� �� ���������� �� ���� ����� � �������]) 
		  AS [�������� �� ���������� �� ���� ����� � �������]
		,SUM([�������� �� ���������� �� ���� ��������]) 
		  AS [�������� �� ���������� �� ���� ��������]
		,SUM([���������� ���������� �� ���� ����� � �������]) 
		  AS [���������� ���������� �� ���� ����� � �������]
		,SUM([���������� ���������� �� ���� ��������]) 
		  AS [���������� ���������� �� ���� ��������]
FROM (
		SELECT	COALESCE(SDA.[CreateDate], LA.[CreateDate])
					AS [Date]
				,COALESCE(PA.[AtomId], 3300)
					AS [AtomId]
				,COALESCE(PA.[Version], 1)
					AS [Version]
				,SUM(CASE WHEN LA.[StageId] = 644 THEN 1 ELSE 0 END) 
					AS [����� �� ���� ����� � �������]
				,0	AS [����� �� ���� ��������]
				,SUM(CASE WHEN LA.[StageId] = 647 THEN 1 ELSE 0 END) 
					AS [�� �������� �� ���� ����� � �������]
				,0	AS [�� �������� �� ���� ��������]
				,SUM(CASE WHEN LA.[StageId] = 649 THEN 1 ELSE 0 END)
					AS [������ �� ���� ����� � �������]
				,0	AS [������ �� ���� ��������]
				,SUM(CASE WHEN LA.[StageId] = 650 THEN 1 ELSE 0 END)
					AS [�������� ��������� �� ���� ����� � �������]
				,0	AS [�������� ��������� �� ���� ��������]
				,SUM(CASE WHEN LA.[StageId] = 653 THEN 1 ELSE 0 END)
					AS [����� �������� �� ���� ����� � �������]
				,0 AS [����� �������� �� ���� ��������]
				,0 AS [���������� �� �������� �� ���� ����� � �������]
				,0 AS [���������� �� �������� �� ���� ��������]
				,0 AS [���������� �������� �� ���� ����� � �������]
				,0 AS [���������� �������� �� ���� ��������]
				,0 AS [�������� �� ���������� �� ���� ����� � �������]
				,0 AS [�������� �� ���������� �� ���� ��������]
				,0 AS [���������� ���������� �� ���� ����� � �������]
				,0 AS [���������� ���������� �� ���� ��������]
		FROM LastApplicants AS LA
		LEFT JOIN StartDateApplicants AS SDA ON LA.[PartnerId] = SDA.[PartnerId]
		LEFT JOIN PartnersAtoms AS PA ON LA.[PartnerId] = PA.[Id]
		GROUP BY COALESCE(SDA.[CreateDate], LA.[CreateDate]), PA.[AtomId], PA.[Version]


		UNION ALL


		SELECT	 LA.[DateLastStageUpdate]
					AS [Date]
				,COALESCE(PA.[AtomId], 3300)
					AS [AtomId]
				,COALESCE(PA.[Version], 1)
					AS [Version]
				,0	AS [����� �� ���� ����� � �������]
				,SUM(CASE WHEN LA.[StageId] = 644 THEN 1 ELSE 0 END)	
					AS [����� �� ���� ��������]
				,0	AS [�� �������� �� ���� ����� � �������]
				,SUM(CASE WHEN LA.[StageId] = 647 THEN 1 ELSE 0 END) 
					AS [�� �������� �� ���� ��������]
				,0	AS [������ �� ���� ����� � �������]
				,SUM(CASE WHEN LA.[StageId] = 649 THEN 1 ELSE 0 END)
					AS [������ �� ���� ��������]
				,0	AS [�������� ��������� �� ���� ����� � �������]
				,SUM(CASE WHEN LA.[StageId] = 650 THEN 1 ELSE 0 END)
					AS [�������� ��������� �� ���� ��������]
				,0 AS [����� �������� �� ���� ����� � �������]
				,SUM(CASE WHEN LA.[StageId] = 653 THEN 1 ELSE 0 END)
					AS [����� �������� �� ���� ��������]
				,0 AS [���������� �� �������� �� ���� ����� � �������]
				,0 AS [���������� �� �������� �� ���� ��������]
				,0 AS [���������� �������� �� ���� ����� � �������]
				,0 AS [���������� �������� �� ���� ��������]
				,0 AS [�������� �� ���������� �� ���� ����� � �������]
				,0 AS [�������� �� ���������� �� ���� ��������]
				,0 AS [���������� ���������� �� ���� ����� � �������]
				,0 AS [���������� ���������� �� ���� ��������]
		FROM LastApplicants AS LA
		LEFT JOIN StartDateApplicants AS SDA ON LA.[PartnerId] = SDA.[PartnerId]
		LEFT JOIN PartnersAtoms AS PA ON LA.[PartnerId] = PA.[Id]
		GROUP BY LA.[DateLastStageUpdate], PA.[AtomId], PA.[Version]


		UNION ALL


		SELECT   COALESCE(SDA.[CreateDate], LA.[CreateDate])
					AS [Date]
				,COALESCE(PA.[AtomId], 3300)
					AS [AtomId]
				,COALESCE(PA.[Version], 1)
					AS [Version]
				,0	AS [����� �� ���� ����� � �������]
				,0	AS [����� �� ���� ��������]
				,0	AS [�� �������� �� ���� ����� � �������]
				,0	AS [�� �������� �� ���� ��������]
				,0	AS [������ �� ���� ����� � �������]
				,0	AS [������ �� ���� ��������]
				,0	AS [�������� ��������� �� ���� ����� � �������]
				,0	AS [�������� ��������� �� ���� ��������]
				,0	AS [����� �������� �� ���� ����� � �������]
				,0	AS [����� �������� �� ���� ��������]
				,SUM(CASE WHEN L.[ActivityId] = 532 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [���������� �� �������� �� ���� ����� � �������]
				,0	AS [���������� �� �������� �� ���� ��������]
				,SUM(CASE WHEN L.[ActivityId] = 595 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END)
					AS [���������� �������� �� ���� ����� � �������]
				,0	AS [���������� �������� �� ���� ��������]
				,SUM(CASE WHEN L.[ActivityId] = 524 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [�������� �� ���������� �� ���� ����� � �������]
				,0	AS [�������� �� ���������� �� ���� ��������]
				,SUM(CASE WHEN L.[ActivityId] = 598 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [���������� ���������� �� ���� ����� � �������]
				,0	AS [���������� ���������� �� ���� ��������]
		FROM LastApplicants AS LA
		LEFT JOIN [client].[CrmLog] AS L ON LA.[Id] = L.[ApplicantId]
		LEFT JOIN StartDateApplicants AS SDA ON LA.[PartnerId] = SDA.[PartnerId]
		LEFT JOIN PartnersAtoms AS PA ON LA.[PartnerId] = PA.[Id]
		GROUP BY LA.[Id], COALESCE(SDA.[CreateDate], LA.[CreateDate]), PA.[AtomId] ,PA.[Version]
		

		UNION ALL


		SELECT   LA.[DateLastStageUpdate]
					AS [Date]
				,COALESCE(PA.[AtomId], 3300)
					AS [AtomId]
				,COALESCE(PA.[Version], 1)
					AS [Version]
				,0	AS [����� �� ���� ����� � �������]
				,0	AS [����� �� ���� ��������]
				,0	AS [�� �������� �� ���� ����� � �������]
				,0	AS [�� �������� �� ���� ��������]
				,0	AS [������ �� ���� ����� � �������]
				,0	AS [������ �� ���� ��������]
				,0	AS [�������� ��������� �� ���� ����� � �������]
				,0	AS [�������� ��������� �� ���� ��������]
				,0	AS [����� �������� �� ���� ����� � �������]
				,0	AS [����� �������� �� ���� ��������]
				,0	AS [���������� �� �������� �� ���� ����� � �������]
				,SUM(CASE WHEN L.[ActivityId] = 532 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [���������� �� �������� �� ���� ��������]
				,0	AS [���������� �������� �� ���� ����� � �������]
				,SUM(CASE WHEN L.[ActivityId] = 595AND L.[State] <> 'cancel' THEN 1 ELSE 0 END)
					AS [���������� �������� �� ���� ��������]
				,0	AS [�������� �� ���������� �� ���� ����� � �������]
				,SUM(CASE WHEN L.[ActivityId] = 524 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [�������� �� ���������� �� ���� ��������]
				,0	AS [���������� ���������� �� ���� ����� � �������]
				,SUM(CASE WHEN L.[ActivityId] = 598 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [���������� ���������� �� ���� ��������]
		FROM LastApplicants AS LA
		LEFT JOIN [client].[CrmLog] AS L ON LA.[Id] = L.[ApplicantId]
		LEFT JOIN PartnersAtoms AS PA ON LA.[PartnerId] = PA.[Id]
		GROUP BY LA.[Id], LA.[DateLastStageUpdate], PA.[AtomId] ,PA.[Version]
	) AS q
GROUP BY [Date], [AtomId], [Version]




GO



