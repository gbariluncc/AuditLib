SELECT dbo.e537a_rcv_hdr.e058_po_nbr AS po_num, 
			 subQ.RcvQty, 
			 subQ.OrdQty, 
			 subQ.PerComp, 
			 dbo.e513_yrd_lct.e513_yrd_lct_nbr AS DoorNum, 
			 dbo.e513_yrd_lct.e514_yrd_zon_nbr AS Zone,
		     dbo.e537a_rcv_hdr.lnd_dm AS Landed, 
			 dbo.e537a_rcv_hdr.sts_cd AS StatusCode,
			 dbo.e537a_rcv_hdr.vnd_nme AS Vendor,
			 dbo.e537a_rcv_hdr.cse_dm as CloseDate,
			 dbo.e537a_rcv_hdr.e539_vnd_nbr_txt as VendorNum,
			 dbo.e537a_rcv_hdr.t063_lct_nbr AS Facility,
			 dbo.e537a_rcv_hdr.shd_arv_dm,
			 dbo.e537a_rcv_hdr.san_cai_acs_id,
			 dbo.e537a_rcv_hdr.cai_trl_id
FROM (dbo.e537a_rcv_hdr 
	LEFT JOIN 
		(SELECT dbo.e538a_rcv_dtl.e058_po_nbr, 
             Sum(dbo.e538a_rcv_dtl.inb_adj_qty_amt) AS OrdQty, 
             Sum(dbo.e538a_rcv_dtl.rcv_qty_amt) AS RcvQty, 
             Sum(dbo.e538a_rcv_dtl.rcv_qty_amt)/Sum(dbo.e538a_rcv_dtl.inb_adj_qty_amt) AS PerComp
             FROM dbo.e538a_rcv_dtl
             GROUP BY dbo.e538a_rcv_dtl.e058_po_nbr
             HAVING (((Sum(dbo.e538a_rcv_dtl.inb_adj_qty_amt))>0))) AS subQ	
	ON dbo.e537a_rcv_hdr.e058_po_nbr = subQ.e058_po_nbr)
	LEFT JOIN 
		dbo.e513_yrd_lct 
	ON (dbo.e537a_rcv_hdr.san_cai_acs_id = dbo.e513_yrd_lct.san_cai_acs_id) AND (dbo.e537a_rcv_hdr.cai_trl_id = dbo.e513_yrd_lct.e512_cai_trl_id)

