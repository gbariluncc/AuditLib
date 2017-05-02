using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Infastructure;

namespace Audits.Database.DMSObjects
{
    public partial class PO : DatabaseObject<PO>, IDMSObject<PO>
    {
        private long _number;
        private long _rcvQty;
        private long _ordQty;
        private double _perComp;
        private int _door;
        private int _zone;
        private DateTime _landed;
        private byte _statusCode;
        private string _vendorName;
        private DateTime _closeDate;
        private string _vendorNumber;
        private int _facility;
        private IRequestItem _requestItem;

        public long po_num { get { return _number; } set { _number = value; OnPropertyChanged(); } }
        public long RcvQty { get { return _rcvQty; } set { _rcvQty = value; OnPropertyChanged(); } }
        public long OrdQty { get { return _ordQty; } set { _ordQty = value; OnPropertyChanged(); } }
        public double PerComp { get { return _perComp; } 
            set { _perComp = value; OnPropertyChanged(); } }
        public int DoorNum { get { return _door; } set { _door = value; OnPropertyChanged(); } }
        public int Zone { get { return _zone; } set { _zone = value; OnPropertyChanged(); } }
        public DateTime Landed { get { return _landed; } set { _landed = value; OnPropertyChanged(); } }
        public byte StatusCode { get { return _statusCode; } set { _statusCode = value; OnPropertyChanged(); } }
        public string Vendor { get { return _vendorName; } set { _vendorName = value; OnPropertyChanged(); } }
        public DateTime CloseDate { get { return _closeDate; } set { _closeDate = value; OnPropertyChanged(); } }
        public string VendorNum { get { return _vendorNumber; } set { _vendorNumber = value; OnPropertyChanged(); } }
        public int Facility { get { return _facility; } set { _facility = value; OnPropertyChanged(); } }
        public DateTime shd_arv_dm { get; set; }
        public string cai_trl_id { get; set; }
        public string san_cai_acs_id { get; set; }


        public PO() { }
        public PO(long value)
        {
            string sql = Properties.Resources.POStatus + " WHERE (dbo.e537a_rcv_hdr.e058_po_nbr = " + value + ")";
            this.CopyFromDMS(sql);

        }
        public PO(IRequestItem requestItem)
            :this(requestItem.Value)
        {
            _requestItem = requestItem;
        }
        public IRequestItem RequestItem
        {
            get { return _requestItem; }
        }
        public override void Add(bool addAll = false, ProgressReporter pg = null)
        {
            throw new NotImplementedException();
        }
        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }

        public static IList<IPO> GetNextPO(long value, POValueType valueType, int facilityNumber = 960)
        {
            List<IPO> poList = new List<IPO>();

            string whereClause = string.Empty;

            switch (valueType)
            {
                case POValueType.VBU_UNKNOWN:
                case POValueType.HOVBU:
                    long vbu = GetSFVBU(value,facilityNumber);
                    value = vbu == -1? value : vbu;
                    goto case POValueType.SFVBU;

                case POValueType.PO:
                    PO tempPO = new PO(value);
                    value = tempPO.ShipFromVBU;
                    goto case POValueType.SFVBU;

                case POValueType.SFVBU:
                    whereClause = "(((LOWES.W001_PO_DAL_HDR.T063_LCT_NBR)={1}) " +
                                 "AND ((LOWES.W001_PO_DAL_HDR.RCP_CD_TXT)='N') " +
                                 "AND ((LOWES.W001_PO_DAL_HDR.P028_VND_NBR)={0}) " +
                                 "AND ((LOWES.W002_PO_DAL_DTL.RCV_QTY)=0))";
                    break;

                case POValueType.ITEM:

                    whereClause = "(((LOWES.W002_PO_DAL_DTL.T063_LCT_NBR)={1}) " +
                                   "AND LOWES.W002_PO_DAL_DTL.RCV_QTY = 0 " +
                                   "AND ((LOWES.W002_PO_DAL_DTL.T024_ITM_NBR)={0}) " +
                                   "AND ((LOWES.W001_PO_DAL_HDR.RCP_CD_TXT)='N'))";
                    break;
                default:
                    break;
            }

            whereClause = string.Format(whereClause, value, facilityNumber);
            ADODB.Recordset rs = HostConnection.GetInstance().Recordset(string.Format(Properties.Resources.GetNextAvailPO, whereClause));

            if (!(rs.BOF && rs.EOF)) 
            { 

                poList = rs.GetPOsFromList().ToList();

                rs.Close();
                rs = null;
            }
            return poList;
        }
        public static IList<IPO> GetPOsForItemList(IList<long> itemNumbers)
        {
            IList<IPO> returnList = new List<IPO>();
            List<List<long>> combos = itemNumbers.GetAllCombos();

            combos.Sort((a, b) => a.Count - b.Count);

            return returnList;
        }

        private static long GetSFVBU(long HOVBU, int facilityNumber)
        {
            string sql = Properties.Resources.FindSFVBU;
            sql = string.Format(sql, HOVBU, facilityNumber);

            ADODB.Recordset rs = HostConnection.GetInstance().Recordset(sql);

            if (rs.BOF && rs.EOF) return -1;

            long VBU = (long)rs.Fields[0].Value;
            rs.Close();
            rs = null;

            return VBU;
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

    }
    public enum POValueType
    {
        SFVBU,
        HOVBU,
        VBU_UNKNOWN,
        ITEM,
        PO
    }
}
