/****** Object:  View [pivotparts].[Crm2]    Script Date: 21.06.2019 7:30:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [pivotparts].[Crm2]
AS
SELECT t1.[Date], t1.[AtomId], t1.[Version], 
	SUM(t1.[Отклики]) AS [Отклики],
	SUM(t1.[Соискатели накопительные]) AS [Соискатели накопительные],
	SUM(t1.[Соискатели валовые]) AS [Соискатели валовые],
	SUM(t1.[Кандидаты накопительные]) AS [Кандидаты накопительные],
	SUM(t1.[Кандидаты валовые]) AS [Кандидаты валовые],
	SUM(t1.[Нанят накопительные]) AS [Нанят накопительные],
	SUM(t1.[Мы отказали накопительные]) AS [Мы отказали накопительные],
	SUM(t1.[Резерв накопительные]) AS [Резерв накопительные],
	SUM(t1.[Кандидат отказался накопительные]) AS [Кандидат отказался накопительные],
	SUM(t1.[Смена вакансии накопительные]) AS [Смена вакансии накопительные],
	SUM(t1.[Нанят валовые]) AS [Нанят валовые],
	SUM(t1.[Мы отказали валовые]) AS [Мы отказали валовые],
	SUM(t1.[Резерв валовые]) AS [Резерв валовые],
	SUM(t1.[Кандидат отказался валовые]) AS [Кандидат отказался валовые],
	SUM(t1.[Смена вакансии валовые]) AS [Смена вакансии валовые],
	SUM(t1.[Нанят по дате кандидата]) AS [Нанят по дате кандидата],
	SUM(t1.[Мы отказали по дате кандидата]) AS [Мы отказали по дате кандидата],
	SUM(t1.[Резерв по дате кандидата]) AS [Резерв по дате кандидата],
	SUM(t1.[Кандидат по дате кандидата]) AS [Кандидат по дате кандидата],
	SUM(t1.[Смена вакансии по дате кандидата]) AS [Смена вакансии по дате кандидата],
	SUM(t1.[Назначено интервью накопительные]) AS [Назначено интервью накопительные],
	SUM(t1.[Результат интервью накопительные]) AS [Результат интервью накопительные],
	SUM(t1.[Назначили на оформление накопительные]) AS [Назначили на оформление накопительные],
	SUM(t1.[Результат оформления накопительные]) AS [Результат оформления накопительные],
	SUM(t1.[Назначено интервью валовые]) AS [Назначено интервью валовые],
	SUM(t1.[Результаты интервью валовые]) AS [Результаты интервью валовые],
	SUM(t1.[Назначили на оформление валовые]) AS [Назначили на оформление валовые],
	SUM(t1.[Результаты оформления валовые]) AS [Результаты оформления валовые],
	SUM(t1.[Назначено интервью по дате кандидата]) AS [Назначено интервью по дате кандидата],
	SUM(t1.[Результаты интервью по дате кандидата]) AS [Результаты интервью по дате кандидата],
	SUM(t1.[Назначили на оформление по дате кандидата]) AS [Назначили на оформление по дате кандидата],
	SUM(t1.[Результаты оформления по дате кандидата]) AS [Результаты оформления по дате кандидата]
FROM (
-- Отклики 
SELECT	[AtomId], [Version], CAST([CreateDate] AS DATE) AS [Date],
	COUNT(*) AS [Отклики],
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результат интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результат оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
FROM [client].[CrmResumeDaxtra]
GROUP BY [AtomId], [Version], CAST([CreateDate] AS DATE)

UNION ALL
 
-- Соискатели накопительные
SELECT ISNULL(R.[AtomId], 3200) AS [AtomId], ISNULL(R.[Version], 1) AS [Version], CAST(R.[CreateDate] AS DATE) AS [Date], 
	0 AS [Отклики], 
	COUNT(*) AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результат интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результат оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
FROM [client].[CrmPartners] AS P
LEFT JOIN [client].[CrmResumeDaxtra] AS R ON P.[Id] = R.[PartnerId]
GROUP BY R.[AtomId], R.[Version], CAST(R.[CreateDate] AS DATE)

UNION ALL

-- Соискатели валовые
SELECT ISNULL(R.[AtomId], 3200) AS [AtomId], ISNULL(R.[Version], 1) AS [Version], CAST(P.[CreateDate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	COUNT(*) AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результат интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результат оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
FROM [client].[CrmPartners] AS P
LEFT JOIN [client].[CrmResumeDaxtra] AS R ON P.[Id] = R.[PartnerId]
GROUP BY R.[AtomId], R.[Version], CAST(P.[CreateDate] AS DATE)

UNION ALL

-- Кандидаты накопительные
SELECT
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date], 
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	COUNT(*) AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результат интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результат оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Кандидаты валовые по атому Отклика
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date], 
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	COUNT(*) AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результат интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результат оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Кандидаты валовые
--SELECT [AtomId] AS [AtomId], [Version] AS [Version], CAST([CreateDate] AS DATE) AS [Date],
	--0 AS [Отклики], 
	--0 AS [Соискатели накопительные],
	--0 AS [Соискатели валовые],
	--0 AS [Кандидаты накопительные],
	--COUNT(*) AS [Кандидаты валовые],
	--0 AS [Нанят накопительные],
	--0 AS [Мы отказали накопительные],
	--0 AS [Резерв накопительные],
	--0 AS [Кандидат отказался накопительные],
	--0 AS [Смена вакансии накопительные],
	--0 AS [Нанят валовые],
	--0 AS [Мы отказали валовые],
	--0 AS [Резерв валовые],
	--0 AS [Кандидат отказался валовые],
	--0 AS [Смена вакансии валовые],
	--0 AS [Назначено интервью накопительные],
	--0 AS [Результат интервью накопительные],
	--0 AS [Назначили на оформление накопительные],
	--0 AS [Результат оформления накопительные],
	--0 AS [Назначено интервью валовые],
	--0 AS [Результаты интервью валовые],
	--0 AS [Назначили на оформление валовые],
	--0 AS [Результаты оформления валовые]
--FROM [client].[CrmApplicants]
--GROUP BY [AtomId], [Version], CAST([CreateDate] AS DATE)
	
UNION ALL

-- Итоги трудоустройства накопительные
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [Нанят накопительные],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [Мы отказали накопительные],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [Резерв накопительные],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [Кандидат отказался накопительные],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результаты интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результаты оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Этапы трудоустройства накопительные
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(RD.[CreateDate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	SUM(CASE WHEN L.[ActivityId] in (532, 719) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Назначено интервью накопительные],
	SUM(CASE WHEN L.[ActivityId] in (595, 721) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Результаты интервью накопительные],
	SUM(CASE WHEN L.[ActivityId] in (524, 722) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Назначили на оформление накопительные],
	SUM(CASE WHEN L.[ActivityId] in (598, 724) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Результаты оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Итоги и этапы трудоустройства валовые	
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[DateLastStageUpdate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [Нанят валовые],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [Мы отказали валовые],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [Резерв валовые],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [Кандидат отказался валовые],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Прошли интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Оформление одобрено накопительные],
	SUM(CASE WHEN A.[StageId] in (642, 909) THEN 1 ELSE 0 END) AS [Назначено интервью валовые],
	SUM(CASE WHEN A.[StageId] = 739 THEN 1 ELSE 0 END) AS [Результаты интервью валовые],
	SUM(CASE WHEN A.[StageId] in (638, 910) THEN 1 ELSE 0 END) AS [Назначили на оформление валовые],
	SUM(CASE WHEN A.[StageId] = 743 THEN 1 ELSE 0 END) AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Итоги трудоустройства по дате кандидата	
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	SUM(CASE WHEN A.[StageId] in (644, 911) THEN 1 ELSE 0 END) AS [Нанят по дате кандидата],
	SUM(CASE WHEN A.[StageId] in (647, 912) THEN 1 ELSE 0 END) AS [Мы отказали по дате кандидата],
	SUM(CASE WHEN A.[StageId] in (649, 913) THEN 1 ELSE 0 END) AS [Резерв по дате кандидата],
	SUM(CASE WHEN A.[StageId] in (650, 914) THEN 1 ELSE 0 END) AS [Кандидат по дате кандидата],
	SUM(CASE WHEN A.[StageId] in (653, 915) THEN 1 ELSE 0 END) AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Прошли интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Оформление одобрено накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	0 AS [Назначено интервью по дате кандидата],
	0 AS [Результаты интервью по дате кандидата],
	0 AS [Назначили на оформление по дате кандидата],
	0 AS [Результаты оформления по дате кандидата]
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

-- Этапы трудоустройства по дате кандидата
SELECT 
	CASE WHEN P.[Id] IS NULL THEN 3200
		 WHEN RD.[PartnerId] IS NULL THEN 3300
		 ELSE RD.[AtomId]
	END AS [AtomId],
	CASE WHEN P.[Id] IS NULL OR RD.[PartnerId] IS NULL THEN 1
		 ELSE RD.[Version]
	END AS [Version],
	CAST(A.[CreateDate] AS DATE) AS [Date],
	0 AS [Отклики], 
	0 AS [Соискатели накопительные],
	0 AS [Соискатели валовые],
	0 AS [Кандидаты накопительные],
	0 AS [Кандидаты валовые],
	0 AS [Нанят накопительные],
	0 AS [Мы отказали накопительные],
	0 AS [Резерв накопительные],
	0 AS [Кандидат отказался накопительные],
	0 AS [Смена вакансии накопительные],
	0 AS [Нанят валовые],
	0 AS [Мы отказали валовые],
	0 AS [Резерв валовые],
	0 AS [Кандидат отказался валовые],
	0 AS [Смена вакансии валовые],
	0 AS [Нанят по дате кандидата],
	0 AS [Мы отказали по дате кандидата],
	0 AS [Резерв по дате кандидата],
	0 AS [Кандидат по дате кандидата],
	0 AS [Смена вакансии по дате кандидата],
	0 AS [Назначено интервью накопительные],
	0 AS [Результаты интервью накопительные],
	0 AS [Назначили на оформление накопительные],
	0 AS [Результаты оформления накопительные],
	0 AS [Назначено интервью валовые],
	0 AS [Результаты интервью валовые],
	0 AS [Назначили на оформление валовые],
	0 AS [Результаты оформления валовые],
	SUM(CASE WHEN L.[ActivityId] in (532, 719) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Назначено интервью по дате кандидата],
	SUM(CASE WHEN L.[ActivityId] in (595, 721) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Результаты интервью по дате кандидата],
	SUM(CASE WHEN L.[ActivityId] in (524, 722) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Назначили на оформление по дате кандидата],
	SUM(CASE WHEN L.[ActivityId] in (598, 724) AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) AS [Результаты оформления по дате кандидата]
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
--Первые кандидаты для конкретного соискателя
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
--Дата входа в воронку соискателя
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
--Последние кандидаты для конкретного соискателя
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
--Атомы соискателей
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
SELECT   CAST([Date] AS DATETIME) AS [Дата]
		,[AtomId]
		,[Version]
		,SUM([Нанят по дате входа в воронку]) 
		  AS [Нанят по дате входа в воронку]
		,SUM([Нанят по дате действия]) 
		  AS [Нанят по дате действия]
		,SUM([Мы отказали по дате входа в воронку]) 
		  AS [Мы отказали по дате входа в воронку]
		,SUM([Мы отказали по дате действия]) 
		  AS [Мы отказали по дате действия]
		,SUM([Резерв по дате входа в воронку]) 
		  AS [Резерв по дате входа в воронку]
		,SUM([Резерв по дате действия]) 
		  AS [Резерв по дате действия]
		,SUM([Кандидат отказался по дате входа в воронку]) 
		  AS [Кандидат отказался по дате входа в воронку]
		,SUM([Кандидат отказался по дате действия]) 
		  AS [Кандидат отказался по дате действия]
		,SUM([Смена вакансии по дате входа в воронку]) 
		  AS [Смена вакансии по дате входа в воронку]
		,SUM([Смена вакансии по дате действия]) 
		  AS [Смена вакансии по дате действия]
		,SUM([Назначение на интервью по дате входа в воронку]) 
		  AS [Назначение на интервью по дате входа в воронку]
		,SUM([Назначение на интервью по дате входа в воронку]) 
		  AS [Назначение на интервью по дате действия]
		,SUM([Результаты интервью по дате входа в воронку]) 
		  AS [Результаты интервью по дате входа в воронку]
		,SUM([Результаты интервью по дате действия]) 
		  AS [Результаты интервью по дате действия]
		,SUM([Назначен на оформление по дате входа в воронку]) 
		  AS [Назначен на оформление по дате входа в воронку]
		,SUM([Назначен на оформление по дате действия]) 
		  AS [Назначен на оформление по дате действия]
		,SUM([Результаты оформления по дате входа в воронку]) 
		  AS [Результаты оформления по дате входа в воронку]
		,SUM([Результаты оформления по дате действия]) 
		  AS [Результаты оформления по дате действия]
FROM (
		SELECT	COALESCE(SDA.[CreateDate], LA.[CreateDate])
					AS [Date]
				,COALESCE(PA.[AtomId], 3300)
					AS [AtomId]
				,COALESCE(PA.[Version], 1)
					AS [Version]
				,SUM(CASE WHEN LA.[StageId] = 644 THEN 1 ELSE 0 END) 
					AS [Нанят по дате входа в воронку]
				,0	AS [Нанят по дате действия]
				,SUM(CASE WHEN LA.[StageId] = 647 THEN 1 ELSE 0 END) 
					AS [Мы отказали по дате входа в воронку]
				,0	AS [Мы отказали по дате действия]
				,SUM(CASE WHEN LA.[StageId] = 649 THEN 1 ELSE 0 END)
					AS [Резерв по дате входа в воронку]
				,0	AS [Резерв по дате действия]
				,SUM(CASE WHEN LA.[StageId] = 650 THEN 1 ELSE 0 END)
					AS [Кандидат отказался по дате входа в воронку]
				,0	AS [Кандидат отказался по дате действия]
				,SUM(CASE WHEN LA.[StageId] = 653 THEN 1 ELSE 0 END)
					AS [Смена вакансии по дате входа в воронку]
				,0 AS [Смена вакансии по дате действия]
				,0 AS [Назначение на интервью по дате входа в воронку]
				,0 AS [Назначение на интервью по дате действия]
				,0 AS [Результаты интервью по дате входа в воронку]
				,0 AS [Результаты интервью по дате действия]
				,0 AS [Назначен на оформление по дате входа в воронку]
				,0 AS [Назначен на оформление по дате действия]
				,0 AS [Результаты оформления по дате входа в воронку]
				,0 AS [Результаты оформления по дате действия]
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
				,0	AS [Нанят по дате входа в воронку]
				,SUM(CASE WHEN LA.[StageId] = 644 THEN 1 ELSE 0 END)	
					AS [Нанят по дате действия]
				,0	AS [Мы отказали по дате входа в воронку]
				,SUM(CASE WHEN LA.[StageId] = 647 THEN 1 ELSE 0 END) 
					AS [Мы отказали по дате действия]
				,0	AS [Резерв по дате входа в воронку]
				,SUM(CASE WHEN LA.[StageId] = 649 THEN 1 ELSE 0 END)
					AS [Резерв по дате действия]
				,0	AS [Кандидат отказался по дате входа в воронку]
				,SUM(CASE WHEN LA.[StageId] = 650 THEN 1 ELSE 0 END)
					AS [Кандидат отказался по дате действия]
				,0 AS [Смена вакансии по дате входа в воронку]
				,SUM(CASE WHEN LA.[StageId] = 653 THEN 1 ELSE 0 END)
					AS [Смена вакансии по дате действия]
				,0 AS [Назначение на интервью по дате входа в воронку]
				,0 AS [Назначение на интервью по дате действия]
				,0 AS [Результаты интервью по дате входа в воронку]
				,0 AS [Результаты интервью по дате действия]
				,0 AS [Назначен на оформление по дате входа в воронку]
				,0 AS [Назначен на оформление по дате действия]
				,0 AS [Результаты оформления по дате входа в воронку]
				,0 AS [Результаты оформления по дате действия]
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
				,0	AS [Нанят по дате входа в воронку]
				,0	AS [Нанят по дате действия]
				,0	AS [Мы отказали по дате входа в воронку]
				,0	AS [Мы отказали по дате действия]
				,0	AS [Резерв по дате входа в воронку]
				,0	AS [Резерв по дате действия]
				,0	AS [Кандидат отказался по дате входа в воронку]
				,0	AS [Кандидат отказался по дате действия]
				,0	AS [Смена вакансии по дате входа в воронку]
				,0	AS [Смена вакансии по дате действия]
				,SUM(CASE WHEN L.[ActivityId] = 532 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Назначение на интервью по дате входа в воронку]
				,0	AS [Назначение на интервью по дате действия]
				,SUM(CASE WHEN L.[ActivityId] = 595 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END)
					AS [Результаты интервью по дате входа в воронку]
				,0	AS [Результаты интервью по дате действия]
				,SUM(CASE WHEN L.[ActivityId] = 524 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Назначен на оформление по дате входа в воронку]
				,0	AS [Назначен на оформление по дате действия]
				,SUM(CASE WHEN L.[ActivityId] = 598 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Результаты оформления по дате входа в воронку]
				,0	AS [Результаты оформления по дате действия]
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
				,0	AS [Нанят по дате входа в воронку]
				,0	AS [Нанят по дате действия]
				,0	AS [Мы отказали по дате входа в воронку]
				,0	AS [Мы отказали по дате действия]
				,0	AS [Резерв по дате входа в воронку]
				,0	AS [Резерв по дате действия]
				,0	AS [Кандидат отказался по дате входа в воронку]
				,0	AS [Кандидат отказался по дате действия]
				,0	AS [Смена вакансии по дате входа в воронку]
				,0	AS [Смена вакансии по дате действия]
				,0	AS [Назначение на интервью по дате входа в воронку]
				,SUM(CASE WHEN L.[ActivityId] = 532 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Назначение на интервью по дате действия]
				,0	AS [Результаты интервью по дате входа в воронку]
				,SUM(CASE WHEN L.[ActivityId] = 595AND L.[State] <> 'cancel' THEN 1 ELSE 0 END)
					AS [Результаты интервью по дате действия]
				,0	AS [Назначен на оформление по дате входа в воронку]
				,SUM(CASE WHEN L.[ActivityId] = 524 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Назначен на оформление по дате действия]
				,0	AS [Результаты оформления по дате входа в воронку]
				,SUM(CASE WHEN L.[ActivityId] = 598 AND L.[State] <> 'cancel' THEN 1 ELSE 0 END) 
					AS [Результаты оформления по дате действия]
		FROM LastApplicants AS LA
		LEFT JOIN [client].[CrmLog] AS L ON LA.[Id] = L.[ApplicantId]
		LEFT JOIN PartnersAtoms AS PA ON LA.[PartnerId] = PA.[Id]
		GROUP BY LA.[Id], LA.[DateLastStageUpdate], PA.[AtomId] ,PA.[Version]
	) AS q
GROUP BY [Date], [AtomId], [Version]




GO



