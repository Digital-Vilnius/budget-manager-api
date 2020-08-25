﻿using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.AccountUser;
using BudgetManager.Contracts.Category;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Contracts.Tag;
using BudgetManager.Contracts.Transaction;
using BudgetManager.Dtos.Account;
using BudgetManager.Dtos.AccountUser;
using BudgetManager.Dtos.Authentication;
using BudgetManager.Dtos.Category;
using BudgetManager.Dtos.Invitation;
using BudgetManager.Dtos.Tag;
using BudgetManager.Dtos.Transaction;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Services.Mapper.Resolvers;

namespace BudgetManager.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoggedUser, LoggedUserDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.User.Id)
                )
                .ForMember(
                    dest => dest.RefreshToken,
                    opt => opt.MapFrom(src => src.User.RefreshToken)
                )
                .ForMember(
                    dest => dest.Locale,
                    opt => opt.MapFrom(src => src.User.Locale)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.User.FullName)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.User.Email)
                );

            CreateMap<User, LoggedUser>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(src => src)
                );

            CreateMap<ListRequest, Paging>();
            CreateMap<ListRequest, Sort>();
            CreateMap<ListRequest, BaseFilter>();
            
            // Tags
            
            CreateMap<Tag, TagsListItemDto>().ForMember(
                dest => dest.Total,
                opt => opt.MapFrom<TagTotalResolver>()
            );
            
            CreateMap<Tag, TagDto>().ForMember(
                dest => dest.Total,
                opt => opt.MapFrom<TagTotalResolver>()
            );
            
            CreateMap<AddTagRequest, Tag>();
            CreateMap<ListTagsRequest, TagsFilter>();
            
            // Invitations

            CreateMap<Invitation, InvitationsListItemDto>();
            CreateMap<Invitation, InvitationDto>();
            
            CreateMap<AddInvitationRequest, Invitation>();
            CreateMap<ListInvitationsRequest, InvitationsFilter>();
            
            // Categories
            CreateMap<Category, CategoriesListItemDto>().ForMember(
                dest => dest.Total,
                opt => opt.MapFrom<CategoryTotalResolver>()
            );
            
            CreateMap<Category, CategoryDto>().ForMember(
                dest => dest.Total,
                opt => opt.MapFrom<CategoryTotalResolver>()
            );
            
            CreateMap<AddCategoryRequest, Category>();
            CreateMap<ListCategoriesRequest, CategoriesFilter>();
            
            // Transactions
            CreateMap<Transaction, TransactionsListItemDto>();
            CreateMap<ListTransactionsRequest, TransactionsFilter>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<AddTransactionRequest, Transaction>();

            // Accounts
            CreateMap<Account, AccountDto>();
            CreateMap<Account, AccountsListItemDto>()
                .ForMember(
                    dest => dest.Balance,
                    opt => opt.MapFrom<BalanceResolver>()
                );
            
            // Account users
            CreateMap<ListAccountUsersRequest, AccountUsersFilter>();
            CreateMap<AccountUser, AccountUsersListItemDto>()
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.User.Email)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.User.FullName)
                );
        }
    }
}