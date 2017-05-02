SELECT 
	LOWES.W001_PO_DAL_HDR.E058_PO_NBR
FROM 
	LOWES.W001_PO_DAL_HDR 
		INNER JOIN LOWES.W002_PO_DAL_DTL 
			ON (LOWES.W001_PO_DAL_HDR.T063_LCT_NBR = LOWES.W002_PO_DAL_DTL.T063_LCT_NBR) 
			AND (LOWES.W001_PO_DAL_HDR.W001_RR_NBR = LOWES.W002_PO_DAL_DTL.W002_RR_NBR) 
			AND (LOWES.W001_PO_DAL_HDR.E058_PO_NBR = LOWES.W002_PO_DAL_DTL.E058_PO_NBR)
WHERE 
	{0}
ORDER BY LOWES.W001_PO_DAL_HDR.ARV_DT;