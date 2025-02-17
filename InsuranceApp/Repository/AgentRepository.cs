using InsuranceApp.Data;
using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly InsuranceContext _context;
        public AgentRepository(InsuranceContext context) { _context = context; }
        public IEnumerable<Agent> GetAll() => _context.Agents.ToList();
    }
}
