﻿using System.Collections.Generic;
using System.Web.Http;

namespace CBHS.Webapi.Controllers
{
    using AutoMapper;
    using CBHS.Business.Interfaces;
    using CBHS.Webapi.Models;

    [RoutePrefix("")]
    public class MembersController : ApiController
    {
        #region Properties

        private IMemberService _service { get; set; }
        private IMapper _mapper;

        #endregion

        public MembersController(IMemberService service)
        {
            _service = service;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.MemberModel, Entity.Member>();
                cfg.CreateMap<Entity.Member, Models.MemberModel>();
            }).CreateMapper();
        }

        //POST: Member
        [HttpPost]
        [Route("members")]
        public bool Add(MemberModel memberModel)
        {
            return _service.Add(_mapper.Map<Models.MemberModel, Entity.Member>(memberModel));
        }

        //GET Member
        [HttpGet]
        [Route("")]
        [Route("members")]
        public IList<MemberModel>  List()
        {
            var listOfMembers = _mapper.Map<IList<Entity.Member>, List<Models.MemberModel>>(_service.List());

            return listOfMembers;
        }

        //GET Member
        [HttpGet]
        [Route("members/oldest")]
        public MemberModel Oldest()
        {
            var OldestMember = _mapper.Map<Entity.Member, Models.MemberModel>(_service.GetOldestMember());

            return OldestMember;
        }
    }
}