﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.Merchandise.Grpc;
using OzonEdu.Merchandise.Services.Interfaces;

namespace OzonEdu.Merchandise.GrpsServices
{
    public class MerchGrpsService : MerchGrpc.MerchGrpcBase
    {
        private readonly IMerchService _merchService;

        public MerchGrpsService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<Empty> RequestMerch(RequestMerchRequest request, ServerCallContext context)
        {
            await _merchService.RequestMerch(request.EmployeeId, context.CancellationToken);
            return null;
        }

        public override  async Task<GetInfoAboutIssuanceMerchResponse> GetInfoAboutIssuanceMerch(
            GetInfoAboutIssuanceMerchRequest request, ServerCallContext context)
        {
            var merchItems =
                await _merchService.GetInfoAboutIssuanceMerch(request.EmployeeId, context.CancellationToken);
            return new GetInfoAboutIssuanceMerchResponse
            {
                Units =
                {
                    merchItems.Select(x => new GetInfoAboutIssuanceMerchResponseUnit()
                    {
                        ItemId = x.ItemId,
                        ItemName = x.ItemName,
                        DateOfIssue = Timestamp.FromDateTime(x.DateOfIssue)
                    })
                }
            };
        }
    }
}