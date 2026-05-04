using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedBillingSystem.Entities;
using AdvancedBillingSystem.Repositories;
using AdvancedBillingSystem.DTOs;

namespace AdvancedBillingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice(InvoiceDto invoiceDto)
        {
            var createdInvoice = await _invoiceRepository.CreateInvoiceAsync(invoiceDto);
            return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceDto invoiceDto)
        {
            if (id != invoiceDto.Id)
            {
                return BadRequest();
            }

            await _invoiceRepository.UpdateInvoiceAsync(invoiceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _invoiceRepository.DeleteInvoiceAsync(id);
            return NoContent();
        }
    }
}