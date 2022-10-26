using AutoMapper;
using WebApi.MovieStore.Application.ActorOperations.Commands.CreateActor;
using WebApi.MovieStore.Application.ActorOperations.Queries.GetActorDetails;
using WebApi.MovieStore.Application.ActorOperations.Queries.GetActors;
using WebApi.MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectorDetails;
using WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Actor
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorsViewModel>();
            CreateMap<ActorsViewModel, Actor>();
            CreateMap<Actor, ActorDetailViewModel>();
            CreateMap<ActorDetailViewModel,Actor>();

            // Director
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director,GetDirectorsQueryModel>();
            CreateMap<Director,GetDirectorsDetailQueryModel>();
        }
    }
}
