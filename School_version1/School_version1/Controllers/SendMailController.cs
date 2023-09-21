using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Services;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public SendMailController( IEmailService service)
        { 
            this.emailService = service;
        }
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(string Email, string comment)
        {
            try
            {
                MailrequestDto mailrequest = new MailrequestDto();
                mailrequest.ToEmail = Email;
                mailrequest.Subject = comment;
                mailrequest.Body = GetHtmlcontent();
                await emailService.SendEmailAsync(mailrequest);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string GetHtmlcontent()
        {
            string Response = "<div class=\"container mt-5\">";
            Response += "<div class=\"row\">";
            Response += "<div class=\"col-md-6\">"; 
            Response += "<img src=\"https://th.bing.com/th/id/OIP.UBBIWMSZ_aOmwEgm0oURKQHaEN?pid=ImgDet&rs=1\" class=\"img-fluid\" alt=\"Cty Nguyễn Đình Hiệp\">";
            Response += "</div>";
            Response += "<div class=\"col-md-6\">";
            Response += " <h1>Cty Nguyễn Đình Hiệp</h1>";
            Response += " <p>\r\n Chúng tôi là một công ty chuyên về các dịch vụ và sản phẩm xuất sắc. Với hơn 20 năm kinh nghiệm, chúng tôi cam kết mang lại sự hài lòng cho khách hàng.\r\n </p>";
            Response += " </div>\r\n        </div>\r\n    </div>";  
            return Response;
        } 
    }
}
