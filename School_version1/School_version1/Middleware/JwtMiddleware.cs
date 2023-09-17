using System.IdentityModel.Tokens.Jwt;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context )
    {
        string authorizationHeader = context.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            await _next(context);
            return;
        }

        string accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();

        // Xác thực mã JWT ở đây và kiểm tra xác thực

        // Ví dụ: Kiểm tra và trích xuất thông tin người dùng từ JWT
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(accessToken);

        // Trích xuất thông tin người dùng từ token
        var username = token.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

        // Lưu thông tin người dùng vào dịch vụ JwtTokenInfo để sử dụng trong Controllers
        context.Items["Username"] = username;
        await _next(context);
    }


}
