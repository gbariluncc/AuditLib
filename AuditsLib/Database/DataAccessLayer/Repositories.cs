using System;
using System.Collections.Generic;
using Audits.Database.DatabaseObjects;

namespace Audits.Database.DataAccessLayer
{
    public interface IAccountRepository : IGenericRepository<Account> { }
    public interface IAccountTypeRepository : IGenericRepository<AccountType> { }
    public interface IAuditRepository : IGenericRepository<Audit> { }
    public interface ICatetoryRepository : IGenericRepository<Category> { }
    public interface IContainerRepository : IGenericRepository<Container> { }
    public interface IDimensionRepository : IGenericRepository<Dimension> { }
    public interface IFacilityRepository : IGenericRepository<Facility> { }
    public interface IFacilityTypeRepository : IGenericRepository<FacilityType> { }
    public interface IPackagingLevelRepository : IGenericRepository<PackagingLevel> { }
    public interface IPictureRepository : IGenericRepository<Picture> { }
    public interface IPriorityRepository : IGenericRepository<Priority> { }
    public interface IProjectRepository : IGenericRepository<Project> { }
    public interface IRatingRepository : IGenericRepository<Rating> { }
    public interface IRequestRepository : IGenericRepository<Request> { }
    public interface IRequestItemRepository : IGenericRepository<RequestItem> { }
    public interface IRoleRepository : IGenericRepository<Role> { }
    public interface ISourceRepository : IGenericRepository<Source> { }
    public interface ITaskRespository : IGenericRepository<Task> { }
    public interface IUserRepository : IGenericRepository<User> { }
    public interface IRequestItemTypeRepository : IGenericRepository<RequestItemType> { }
    public interface IStatusRepository : IGenericRepository<Status> { }
    public interface IDCIssueRepository : IGenericRepository<DCIssue> { }
    public interface IDCIssueItemRepository : IGenericRepository<DCIssueItem> { }
    public interface IFailedSampleRepository : IGenericRepository<FailedSample> { }
    public interface IDCIssueFacilityRepository : IGenericRepository<DCIssueFacility> { }
    public interface IRequestCategoryRepository : IGenericRepository<RequestCategory> { }

    public class DCIssueItemRepository : GenericRepository<DCIssueItem>, IDCIssueItemRepository { }
    public class DCIssueFacilityRepository : GenericRepository<DCIssueFacility>, IDCIssueFacilityRepository { }
    public class FailedSampleRepository : GenericRepository<FailedSample>, IFailedSampleRepository { }
    public class AccountRepository : GenericRepository<Account>, IAccountRepository { }
    public class AccountTypeRepository : GenericRepository<AccountType>, IAccountTypeRepository { }
    public class AuditRepository : GenericRepository<Audit>, IAuditRepository { }
    public class CategoryRepository : GenericRepository<Category>, ICatetoryRepository { }
    public class ContainerRepository : GenericRepository<Container>, IContainerRepository { }
    public class DimensionRepository : GenericRepository<Dimension>, IDimensionRepository { }
    public class FacilityRepository : GenericRepository<Facility>, IFacilityRepository { }
    public class FacilityTypeRepository : GenericRepository<FacilityType>, IFacilityTypeRepository { }
    public class PackagingLevelRepository : GenericRepository<PackagingLevel>, IPackagingLevelRepository { }
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository { }
    public class PriorityRepository : GenericRepository<Priority>, IPriorityRepository { }
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository { }
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository { }
    public class RequestRepository : GenericRepository<Request>, IRequestRepository { }
    public class RequestItemRepository : GenericRepository<RequestItem>, IRequestItemRepository { }
    public class RequestItemTypeRepository : GenericRepository<RequestItemType>, IRequestItemTypeRepository { }
    public class RoleRepository : GenericRepository<Role>, IRoleRepository { }
    public class SourceRepository : GenericRepository<Source>, ISourceRepository { }
    public class StatusRepository : GenericRepository<Status>, IStatusRepository { }
    public class TaskRespository : GenericRepository<Task>, ITaskRespository { }
    public class UserRepository : GenericRepository<User>, IUserRepository { }
    public class DCIssueRepository : GenericRepository<DCIssue>, IDCIssueRepository { }
    public class RequestCategoryRepository : GenericRepository<RequestCategory>, IRequestCategoryRepository { }
}
