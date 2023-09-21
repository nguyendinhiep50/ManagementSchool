using AutoMapper.Internal;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailrequestDto mailrequest);
    }
}
