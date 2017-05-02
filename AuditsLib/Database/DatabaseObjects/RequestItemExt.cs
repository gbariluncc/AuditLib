using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using Audits.Database;
using Audits.Database.DMSObjects;

namespace Audits.Database.DatabaseObjects
{
    public partial class RequestItem : DatabaseObject<RequestItem>, IRequestItem, IEquatable<RequestItem>
    {
        private string _desc = string.Empty;

        public virtual long RequestItemID
        {
            get
            {
                return req_itm_id;
            }
            set
            {
                req_itm_id = value;
            }
        }
        public virtual string DisplayValue
        {
            get
            {
                if (RequestItemType == null) { return "Unknown Type."; }
                return RequestItemType.Description + " " + Value;
            }
        }
        public virtual IFailedSample FailedSample
        {
            get
            {
                //this will be an issue if there are multiple POs with the same item number failing.  Right now
                //set to first, and it may need to condense to one record on the intake side.
                return new FailedSample().Where("itm_num=" + Value).FirstOrDefault();
            }
        }
        public virtual IDCIssueItem DCIssueItem
        {
            get
            {
                return new DCIssueItem().Where("itm_num=" + Value).SingleOrDefault();
            }
        }

        public virtual byte ItemTypeID
        {
            get
            {
                return itm_typ_id;
            }
            set
            {
                itm_typ_id = value;
            }
        }

        public virtual int Value
        {
            get
            {
                return req_itm_val;
            }
            set
            {
                req_itm_val = value;
            }
        }

        public virtual byte StatusCode
        {
            get
            {
                return sts_cd;
            }
            set
            {
                sts_cd = value;
                if (sts_cd != Status.StatusCode)
                {
                    Status = DBContext.Instance.Status.GetSingle(s => s.sts_cd == sts_cd);
                }
            }
        }
        public virtual long VBU
        {
            get { return vbu; }
            set { vbu = value; }
        }
        public virtual long? ParentID
        {
            get
            {
                return req_itm_par_id == 0? null : new long?(req_itm_par_id);
            }
            set
            {
                req_itm_par_id = value == null ? 0 : value.Value;
            }
        }

        public virtual DateTime AddDate
        {
            get
            {
                return req_itm_add_dt;
            }
            set
            {
                req_itm_add_dt = value;
            }
        }
        public virtual string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_desc))
                {
                    _desc = GetDescription();
                }
                return _desc;
            }
        }
        public virtual DateTime UpdateDate
        {
            get
            {
                return req_itm_upd_dt;
            }
            set
            {
                req_itm_upd_dt = value;
            }
        }

        public virtual DateTime ExpDate
        {
            get
            {
                return req_itm_exp_dt;
            }
            set
            {
                req_itm_exp_dt = value;
            }
        }

        public virtual long RequestID
        {
            get
            {
                return req_id;
            }
            set
            {
                req_id = value;
            }
        }

        public virtual byte ContainerType
        {
            get
            {
                return cont_typ;
            }
            set
            {
                cont_typ = value;
            }
        }

        public virtual string Comments
        {
            get
            {
                return req_itm_comm;
            }
            set
            {
                req_itm_comm = value;
            }
        }

        ICollection<IAudit> IRequestItem.Audits
        {
            get
            {
                return Audits.ToHashSet<IAudit>();
            }
            set
            {
                Audits = InterfaceConverter.ConvertToCollection<Audit, IAudit>(value);
            }
        }

        IContainer IRequestItem.Container
        {
            get
            {
                return Container;
            }
            set
            {
                Container = (Container)value;
            }
        }

        ICollection<IDimension> IRequestItem.Dimensions
        {
            get
            {
                return Dimensions.ToHashSet<IDimension>();
            }
            set
            {
                Dimensions = InterfaceConverter.ConvertToCollection<Dimension, IDimension>(value);
            }
        }

        ICollection<IPicture> IRequestItem.Pictures
        {
            get
            {
                return Pictures.ToHashSet<IPicture>();
            }
            set
            {
                Pictures = InterfaceConverter.ConvertToCollection<Picture, IPicture>(value);
            }
        }

        IRequest IRequestItem.Request
        {
            get
            {
                return Request;
            }
            set
            {
                Request = (Request)value;
            }
        }
        public string DCIssuesText
        {
            get
            {
                if (DCIssueItem != null)
                {
                    IDCIssue temp = DCIssueItem.DCIssue;

                    return temp.DCIssueDescription;
                }
                else { return string.Empty; }
            }
        }
        public string FailedSampleText
        {
            get
            {
                if (FailedSample != null)
                {
                    string sum = FailedSample.FailSummary;
                    string com = FailedSample.GeneralComments;

                    if (string.IsNullOrEmpty(sum) || string.IsNullOrEmpty(com))
                    {
                        return sum + com;
                    }
                    else
                    {
                        return "Failure: " + sum + "\nComments: " + com;
                    }
                }
                else { return string.Empty; }
            }
        }
        IRequestItemType IRequestItem.RequestItemType
        {
            get
            {
                return RequestItemType;
            }
            set
            {
                RequestItemType = (RequestItemType)value;
            }
        }

        ICollection<IRequestItem> IRequestItem.Children
        {
            get
            {
                return Children.ToHashSet<IRequestItem>();
            }
            set
            {
                Children = InterfaceConverter.ConvertToCollection<RequestItem, IRequestItem>(value);
            }
        }

        IRequestItem IRequestItem.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = (RequestItem)value;
            }
        }

        IStatus IRequestItem.Status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = (Status)value;
                if (Status != null && Status.StatusCode != StatusCode)
                {
                    StatusCode = Status.StatusCode;
                }
            }
        }

        IRequestItem IRequestItem.RequestItem
        {
            get
            {
                return this;
            }
            set
            {
                
            }
        }
        private string GetDescription()
        {
            string sql = string.Empty;
            ADODB.Recordset rs;

            switch (ItemTypeID)
            {
                case 1:
                    if (DMSConnection.GetInstance().Connection != null)
                    {
                        sql = "SELECT itm_desc FROM dbo.item WHERE itm_num=" + Value;
                    }
                    else if(HostConnection.GetInstance().Connection != null)
                    { 
                        sql = "SELECT ITM_DES_TXT FROM Lowes.T024_ITM WHERE T024_ITM_NBR=" + Value; 
                    }
                    break;
                case 2:
                    if (DMSConnection.GetInstance().Connection != null)
                    {
                        sql = "SELECT vnd_nme FROM dbo.e537a_rcv_hdr WHERE e058_po_nbr =" + Value;
                    }
                    else if(HostConnection.GetInstance().Connection != null) 
                    {
                        sql = "SELECT VND_NME FROM Lowes.W001_PO_DAL_HDR WHERE E058_PO_NBR=" + Value;  
                    }
                    break;
                case 3:
                    Facility fac = new Facility().Where("fac_num=" + Value).SingleOrDefault();
                    return fac == null ? string.Empty : fac.Name;
                case 4:
                    string retVal = "Unknown vendor.";

                    if (HostConnection.GetInstance().Connection != null)
                    {
                        sql = "SELECT VBU_NME FROM LOWES.T616_VBU WHERE T616_VBU_NBR=" + Value + " AND T617_FNC_TYP_CD=1";
                        try
                        {
                            retVal = HostConnection.GetInstance().Recordset(sql).Fields[0].Value.ToString();
                        }
                        catch (Exception) { retVal = "Unknown Vendor."; }
                    }
                    return retVal;
                default:
                    return "Unknown.";
            }

            if (DMSConnection.GetInstance().Connection != null)
            {
                rs = DMSConnection.GetInstance().Recordset(sql);
            }
            else
            {
                rs = HostConnection.GetInstance().Recordset(sql);
            }

            string output;
            try
            {
                if (!(rs.BOF && rs.EOF))
                {
                    output = rs.Fields[0].Value.ToString();
                }
                else { output = "Unknown."; }
            }
            catch (Exception) { output = "Unknown error occured."; }
            rs.Close();
            rs = null; 
            //string output = "Not implimented yet.";
            return output;
        }


        public DBObjectState ObjectState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Equals(RequestItem other)
        {
            return this == other;
        }
        public static bool operator ==(RequestItem obj1, RequestItem obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (object.ReferenceEquals(obj1, null) ||
                object.ReferenceEquals(obj2, null))
            {
                return false;
            }
            return (obj1.RequestID == obj2.RequestID && obj1.Value == obj2.Value && obj1.req_itm_par_id == obj2.req_itm_par_id && obj1.cont_typ == obj2.cont_typ);
        }
        public static bool operator !=(RequestItem obj1, RequestItem obj2)
        {
            return !(obj1 == obj2);
        }
        public override bool Equals(object obj)
        {
            if (obj is RequestItem)
            {
                return this == (RequestItem)obj;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        
    }
}
