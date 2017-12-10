using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Datasource
{
    public class DataRepository : IDataRepository
    {
        private IMapper _mapper;

        public DataRepository()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity.Member, Datasource.Member>();
                cfg.CreateMap<Datasource.Member, Entity.Member>();
            }).CreateMapper();
        }

        public bool AddMember(Entity.Member member)
        {
            //member.MemberId = members.Count() + 1;
            try
            {
                //members.Add(member);
                using (var db = new CBHSDBContext())
                {
                    db.Members.Add(_mapper.Map<Entity.Member, Datasource.Member>(member));
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log the exception
                return false;
            }
        }

        public List<Entity.Member> GetMembers()
        {
            var result = new List<Entity.Member>();

            using (var db = new CBHSDBContext())
            {
                var query = from m in db.Members
                            orderby m.MemberId descending
                            select m;

                result = _mapper.Map<List<Datasource.Member>, List<Entity.Member>>(query.ToList<Member>());
            }

            return result;
        }
    }
}