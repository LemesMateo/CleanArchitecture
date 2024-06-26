using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videRepository, IMapper mapper)
        {
            _videRepository = videRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videRepository.GetVideoByUsername(request._Username);
            
            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
