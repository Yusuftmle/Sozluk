using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Api.Application.Features.Queries.GetEntries
{
    public class GetEntriesQueries:IRequest<List< GetEntriesViewModel>>
    {
        public bool TodaysEntries { get; set; }
        public int Count { get; set; } = 100;
    }


}
