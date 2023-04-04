using Microsoft.AspNetCore.Mvc;
using OSLTest.Repos;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace OSLTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountsRepository _accountsRepository;

        public AccountsController(ILogger<AccountsController> logger, IAccountsRepository accountsRepository)
        {
            _logger = logger;
            _accountsRepository = accountsRepository;
        }

        [HttpGet(Name = "GetAccount")]
        public async Task<IActionResult> Get(string accountId)
        {
            var isNumeric = Regex.IsMatch(accountId, @"^\d+$");

            if (!isNumeric)
            {
                return BadRequest("Account Id must be a number");
            }

            //here must be request to repository via mediator 
            var account = _accountsRepository.GetAccount(accountId);

            return Ok(account);
        }

        [HttpGet("/accounts/{accountId}/transactions")]
        public async Task<IActionResult> GetTransactions(string accountId)
        {
            var isNumeric = Regex.IsMatch(accountId, @"^\d+$");

            if (!isNumeric)
            {
                return BadRequest("Account Id must be a number");
            }

            var transaction = _accountsRepository.GetTransactions(accountId);

            return Ok(transaction);
        }


        [HttpPost(Name = "PostAccount")]
        public async Task<IActionResult> PostAccount([FromBody] Account account)
        {
            //here must be Mediator call with validation inside but for simplicity I do it on fields

            if (string.IsNullOrEmpty(account.AccountType))
            {
                return BadRequest("AccountType field is required");
            }
            if (account.Balance <= 0)
            {
                return BadRequest("Balance field must be positive number");
            }
            if (account.Currency is not "USD" && account.Currency is not "EUR")
            {
                return BadRequest("Currency must be USD or EUR");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Name))
            {
                return BadRequest("Account holder name is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Email))
            {
                return BadRequest("Account holder email is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Address.Line1))
            {
                return BadRequest("Account holder address is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Address.Country))
            {
                return BadRequest("Account holder address country is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Address.City))
            {
                return BadRequest("Account holder address city is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Address.State))
            {
                return BadRequest("Account holder address state is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.Address.ZipCode))
            {
                return BadRequest("Account holder address zipcode is required");
            }
            if (string.IsNullOrEmpty(account.AccountHolder.PhoneNumber))
            {
                return BadRequest("Account holder phone number is required");
            }

            _accountsRepository.PostAccount(account);

            return Ok();
        }

        [HttpPost("/accounts/{accountId:int}/debits")]
        public async Task<IActionResult> PostDebit(int accountId, SendDebitRequest sendDebitRequest)
        {
            //I dont use accountId for simplicity but in real proj it would be used as a foreign key to save Debit obj in db.

            if (string.IsNullOrEmpty(sendDebitRequest.Description))
            {
                return BadRequest("Description field is required");
            }
            if (sendDebitRequest.Amount <= 0)
            {
                return BadRequest("Amount field must be positive number");
            }

            //Here must be automapper
            var debit = new Debit();
            debit.Amount = sendDebitRequest.Amount;
            debit.Currency = sendDebitRequest.Currency;
            debit.Description = sendDebitRequest.Description;

            _accountsRepository.PostDebit(debit);

            return Ok();
        }

        [HttpPost("/accounts/{accountId:int}/credits")]
        public async Task<IActionResult> PostCredit(int accountId, SendCreditRequest sendcreditRequest)
        {
            //I dont use accountId for simplicity but in real proj it would be used as a foreign key to save Credit obj in db.

            if (string.IsNullOrEmpty(sendcreditRequest.Description))
            {
                return BadRequest("Description field is required");
            }
            if (sendcreditRequest.Amount <= 0)
            {
                return BadRequest("Amount field must be positive number");
            }

            var credit = new Credit();
            credit.Amount = sendcreditRequest.Amount;
            credit.Currency = sendcreditRequest.Currency;
            credit.Description = sendcreditRequest.Description;

            _accountsRepository.PostCredit(credit);

            return Ok();
        }
    }
}
