using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DataAccessLayer
{
    public class DBContext
    {
        private static DBContext _context;
        private IAccountRepository _accounts;
        private IAccountTypeRepository _accountTypes;
        private IAuditRepository _audits;
        private ICatetoryRepository _categories;
        private IContainerRepository _containers;
        private IDimensionRepository _dimensions;
        private IFacilityRepository _facilities;
        private IFacilityTypeRepository _facilityTypes;
        private IUserRepository _users;
        private IPackagingLevelRepository _packagingLevels;
        private IPictureRepository _pictures;
        private IPriorityRepository _priorities;
        private IProjectRepository _projects;
        private IRatingRepository _ratings;
        private IRequestRepository _requests;
        private IRequestItemRepository _requestItems;
        private IRequestItemTypeRepository _requestItemTypes;
        private IRoleRepository _roles;
        private ISourceRepository _sources;
        private IStatusRepository _status;
        private ITaskRespository _tasks;
        private IFailedSampleRepository _failedSamples;
        private IDCIssueFacilityRepository _dcIssuesFacilities;
        private IDCIssueItemRepository _dcIssueItems;
        private IDCIssueRepository _dcIssues;
        private IRequestCategoryRepository _requestCategories;

        private DBContext()
        {
            _accounts = new AccountRepository();
            _accountTypes = new AccountTypeRepository();
            _audits = new AuditRepository();
            _categories = new CategoryRepository();
            _containers = new ContainerRepository();
            _dimensions = new DimensionRepository();
            _facilities = new FacilityRepository();
            _facilityTypes = new FacilityTypeRepository();
            _priorities = new PriorityRepository();
            _users = new UserRepository();
            _packagingLevels = new PackagingLevelRepository();
            _pictures = new PictureRepository();
            _projects = new ProjectRepository();
            _ratings = new RatingRepository();
            _requests = new RequestRepository();
            _requestItems = new RequestItemRepository();
            _requestItemTypes = new RequestItemTypeRepository();
            _roles = new RoleRepository();
            _sources = new SourceRepository();
            _status = new StatusRepository();
            _status = new StatusRepository();
            _tasks = new TaskRespository();
            _dcIssueItems = new DCIssueItemRepository();
            _dcIssues = new DCIssueRepository();
            _dcIssuesFacilities = new DCIssueFacilityRepository();
            _failedSamples = new FailedSampleRepository();
            _requestCategories = new RequestCategoryRepository();
        }
        public static DBContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new DBContext();
                }
                return _context;
            }
        }
        public IRequestCategoryRepository RequestCategories
        {
            get
            {
                return _requestCategories;
            }
        }
        public IFailedSampleRepository FailedSamples
        {
            get { return _failedSamples; }
        }
        public IDCIssueFacilityRepository DCIssueFacilities
        {
            get { return _dcIssuesFacilities; }
        }
        public IDCIssueItemRepository DCIssueItems
        {
            get { return _dcIssueItems; }
        }
        public IDCIssueRepository DCIssues
        {
            get { return _dcIssues; }
        }
        public IUserRepository Users
        {
            get { return _users; }
        }
        public IAccountRepository Accounts
        {
            get { return _accounts; }
        }
        public IAccountTypeRepository AccountTypes
        {
            get { return _accountTypes; }
        }
        public IAuditRepository Audits
        {
            get { return _audits; }
        }
        public ICatetoryRepository Categories
        {
            get { return _categories; }
        }
        public IContainerRepository Containers
        {
            get { return _containers; }
        }
        public IDimensionRepository Dimensions
        {
            get { return _dimensions; }
        }
        public IFacilityRepository Facilities
        {
            get { return _facilities; }
        }
        public IFacilityTypeRepository FacilityTypes
        {
            get { return _facilityTypes; }
        }
        public IPackagingLevelRepository PackagingLevels
        {
            get { return _packagingLevels; }
        }
        public IPictureRepository Pictures
        {
            get { return _pictures; }
        }
        public IProjectRepository Projects
        {
            get { return _projects; }
        }
        public IRatingRepository Ratings
        {
            get { return _ratings; }
        }
        public IRequestRepository Requests
        {
            get { return _requests; }
        }
        public IRequestItemRepository RequestItems
        {
            get { return _requestItems; }
        }
        public IRequestItemTypeRepository RequestItemTypes
        {
            get { return _requestItemTypes; }
        }
        public IRoleRepository Roles
        {
            get { return _roles; }
        }
        public ISourceRepository Sources
        {
            get { return _sources; }
        }
        public IStatusRepository Status
        {
            get { return _status; }
        }
        public ITaskRespository Tasks
        {
            get
            {
                return _tasks;
            }
        }
        public IPriorityRepository Priorities
        {
            get { return _priorities; }
        }
    }
}
