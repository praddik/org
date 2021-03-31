using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Company;

namespace Web.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICrudCompanyService _ServiceRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICrudCompanyService repository, IMapper mapper)
        {
            _ServiceRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies = await _ServiceRepository.GetAll();
            var companyModels =
                _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyModel>>(companies);
            return Ok(companyModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Company company = await _ServiceRepository.GetById(id);
            var companyModel = _mapper.Map<Company, CompanyModel>(company);
            return Ok(companyModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyModel company)
        {
            Company companyToCreate = _mapper.Map<CreateCompanyModel, Company>(company);
            Company newCompany = await _ServiceRepository.Create(companyToCreate);
            var companyModel = _mapper.Map<Company, CompanyModel>(newCompany);
            return Ok(companyModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCompanyModel company)
        {
            Company companyToUpdate = _mapper.Map<UpdateCompanyModel, Company>(company);
            companyToUpdate.Id = id;
            Company updatedCompany = await _ServiceRepository.Update(companyToUpdate);
            var companyModel = _mapper.Map<Company, CompanyModel>(updatedCompany);
            return Ok(companyModel);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdateCompanyModel company)
        {
            Company companyToUpdate = _mapper.Map<UpdateCompanyModel, Company>(company);
            companyToUpdate.Id = id;
            Company updatedCompany = await _ServiceRepository.Update(companyToUpdate);
            var companyModel = _mapper.Map<Company, Company>(updatedCompany);
            return Ok(companyModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceRepository.Delete(new Company { Id = id });
            return Ok();
        }
    }
}
