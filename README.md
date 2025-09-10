<img width="1969" height="781" alt="image" src="https://github.com/user-attachments/assets/bbe35250-9afc-40c2-912d-886470c6f52c" /># Content negotiation in Web/REST API:
we acn restrict the content return type
![image](https://github.com/user-attachments/assets/53bbb292-9527-49c8-819b-03fb09d073cf)
![image](https://github.com/user-attachments/assets/6f60729f-d649-4ae8-8f5e-67349b950d3e)

Now it Will accept in xml format as well
![image](https://github.com/user-attachments/assets/33445ade-029c-4be6-a7d0-01601addd438)
![image](https://github.com/user-attachments/assets/fc964b43-1bbf-4d60-942a-68d39a023cae)

# AddSingleton
![image](https://github.com/user-attachments/assets/06b0d6aa-5c0a-4a53-80ab-f5a4e54d7938)

# AddScoped
![image](https://github.com/user-attachments/assets/9e6f5381-d4b2-4a4c-a61d-e0b02f40d821)

#AddTransient
![image](https://github.com/user-attachments/assets/a9d5952e-43ac-4308-9746-0a7303bd0b9f)

![image](https://github.com/user-attachments/assets/c4919957-dfb8-4ff1-a735-f4ba119b9757)

![image](https://github.com/user-attachments/assets/6a6ea75e-ef79-412d-869d-86370978b6f7)

![image](https://github.com/user-attachments/assets/8091dfd6-bb55-4be7-8e69-cb28b157d0c9)


# Logger
### Console and debug Mode logger we can use without any configuration
 ![image](https://github.com/user-attachments/assets/34683afe-1106-4632-aaa5-4cf938115e1e)
 ![image](https://github.com/user-attachments/assets/a9b27933-28a1-442d-836f-67efdffef6bc)

#### We can remove all the default logger(Console, Debug, EventSource, EventLog (Windows only)) by using this:

![image](https://github.com/user-attachments/assets/8d6917af-853f-467a-805c-a49dedc7754c)

#### Now we can enable any of the mode like this

![image](https://github.com/user-attachments/assets/d846d272-9609-469b-81d5-13fe90b0cf1f)

![image](https://github.com/user-attachments/assets/48d9567a-3a53-4688-9fa4-407994ad55fa)

### Log Levels in Web api
 
![image](https://github.com/user-attachments/assets/9340a845-e71d-486e-9d2a-875cc08cdd0e)

![image](https://github.com/user-attachments/assets/ef204864-f263-4dd1-ba64-3b7627e0a207)

#### It will log 2 level’s only (Error and Critical) as for console app we have set Default as Error
![image](https://github.com/user-attachments/assets/a2653fc0-f85c-416f-a960-364542178604)
![image](https://github.com/user-attachments/assets/cf7fdd1d-f7f2-4b89-b80f-645a1ee1025d)

#### For Debug provider it will log all the levels
 
![image](https://github.com/user-attachments/assets/69753996-28e9-437a-aafa-5e3caabc9d1e)


## Entity Framework
### Need to download the below packages
![image](https://github.com/user-attachments/assets/7a15aa76-5175-4cb5-9dc2-90153ba5a94c)

![image](https://github.com/user-attachments/assets/2be3dd20-a8f2-4634-b47f-602f538167fb)

![image](https://github.com/user-attachments/assets/5c5900ed-17f4-49c1-9f63-5998db88aad8)

![image](https://github.com/user-attachments/assets/6146799b-13e9-47f2-9f6c-d6444c268060)

### Code First
1. Create Model
   ![image](https://github.com/user-attachments/assets/2a6d60e8-d68d-49a7-a8ff-a3a657195346)
2. Create Db context and DbSet
   ![image](https://github.com/user-attachments/assets/811e2f03-05c5-40b0-923e-515409d5da20)
3. Configure connection string(we are doing windows authentication)
   ![image](https://github.com/user-attachments/assets/aa69ab4d-ed1a-4e78-aa4a-d8b7b125b9bf)
   "ConnectionStrings": {
  "CollegeDBConnection": "Data Source=ArghyaGhosh;Initial Catalog=CollegeDBProject;Integrated Security=True;Trust Server Certificate=True",
 }
4. register DbContext in program.cs
   ![image](https://github.com/user-attachments/assets/8cbbb1af-c7d2-4eff-9554-199f4205d365)

5. First run 'Add-Migration Initialmigration' command. It will create maigration file.
6. To update dataBase need to run "Update-Database" command.

![image](https://github.com/user-attachments/assets/4ee0418c-91a7-4a3c-91fe-b33d51d79b97)
![image](https://github.com/user-attachments/assets/8fc650dd-d00c-4cd7-a54f-d2f88f2fc054)

#### Add default data to tables in EF Code First
![image](https://github.com/user-attachments/assets/8347ae22-e8b8-4179-9c36-51fb2e621b42)

#### Migrate tables with proper schema Datatype
![image](https://github.com/user-attachments/assets/c2fa0d66-3891-401b-8b04-cb6518442fce)

![image](https://github.com/user-attachments/assets/c226d0f4-5ce4-4e43-8378-09ebd8d61b99)

![image](https://github.com/user-attachments/assets/a134cad2-d69d-4dc9-82e0-7f56d7da2bcc)

#### Creating separate EntityTypeConfiguration file for each table
1. Create a config file
![image](https://github.com/user-attachments/assets/1080316c-d336-4cc3-9b0d-f6bbdfb8e4fe)

2. Remove all the configuration from context file
   ![image](https://github.com/user-attachments/assets/c9ad9058-1853-41c4-ab0c-1de6e7f250b7)

3. Add our new configuration class in the context file
   
![image](https://github.com/user-attachments/assets/3cdc15d9-19f1-4c3b-abf4-4a3d7577aa9d)

## AsNoTracking in Entity framework
![image](https://github.com/user-attachments/assets/123d40e1-3c64-4492-bde6-b86a32ff40e7)

## Using AutoMapper in Web API

| Step | Action                               |
| ---- | ------------------------------------ |
| 1    | Install AutoMapper NuGet packages    |
| 2    | Create mapping profile(s)            |
| 3    | Register AutoMapper in `Program.cs`  |
| 4    | Inject and use `IMapper` in your app |

![image](https://github.com/user-attachments/assets/43de7c33-3130-47d7-90dd-9e4833b792d1)

Documentation: https://docs.automapper.org/en/stable/Configuration.html#profile-instances
![image](https://github.com/user-attachments/assets/76b75946-8afd-480e-b79d-e9759b915bae)
![image](https://github.com/user-attachments/assets/311503ec-a563-4650-b46f-c9f48f945618)
![image](https://github.com/user-attachments/assets/c1bc9978-297b-46ac-b91c-d0860ddf0fe2)

## Auto mapper with different property names, ignore, transform

#### When we have diff property
![image](https://github.com/user-attachments/assets/b769c93c-6e7d-4879-b4d0-fa9e024acb37)
![image](https://github.com/user-attachments/assets/0c0a59b6-3f14-4529-8a27-ecb55eafcf9c)

![image](https://github.com/user-attachments/assets/e40a8633-bad4-4199-af69-36b023bd8421)
![image](https://github.com/user-attachments/assets/d184c927-6418-449b-a55f-b200dd06dc7d)

#### Ignore
![image](https://github.com/user-attachments/assets/5873a6d2-1932-4185-8dd0-269c1cc3e5cc)
![image](https://github.com/user-attachments/assets/5c41a746-5957-45af-b2b1-d35ac92a45bb)

#### Set default message if any string property null
![image](https://github.com/user-attachments/assets/a6fb0e93-b9d2-4de1-a6e6-71aa736b8cf1)
![image](https://github.com/user-attachments/assets/cad94a05-8664-4d84-9d1e-3aeb8ff223d3)

#### Set a message for Address property
![image](https://github.com/user-attachments/assets/f7bacd75-f07b-4962-a79a-3f8fface3742)

![image](https://github.com/user-attachments/assets/dcc3699d-7067-4864-bf3b-242283af35db)

# Repository design pattern in Web API

![image](https://github.com/user-attachments/assets/3091b039-a740-4fa3-8770-5bd9ed36a1c1)

![image](https://github.com/user-attachments/assets/ba85e632-b1ef-4556-b3d4-bb6fd6cd71ec)
![image](https://github.com/user-attachments/assets/db22cef7-6e36-4028-ae35-25bd4cb3e347)

![image](https://github.com/user-attachments/assets/3b064b88-cf0a-4dea-9701-2c5a32635081)
but we will not create diff repository instead we will create a common repository
![image](https://github.com/user-attachments/assets/5fd17a18-69ea-4121-9336-622051f03731)

## Creating Foreign Key in Entity Framework code first in Web API

<img width="2263" height="916" alt="image" src="https://github.com/user-attachments/assets/232a9750-87c5-4036-8acf-dbf1273322aa" />
<img width="984" height="398" alt="image" src="https://github.com/user-attachments/assets/18f8dbe3-f45e-489a-a983-6cee56e52459" />
<img width="818" height="264" alt="image" src="https://github.com/user-attachments/assets/78ca1137-268a-44c4-bc27-9be3aacecef7" />


## CORS - Cross Origin Resource Sharing

<img width="2176" height="962" alt="image" src="https://github.com/user-attachments/assets/97ea508d-0c28-4b45-8da9-2dff4b7d2b43" />
<img width="2004" height="931" alt="image" src="https://github.com/user-attachments/assets/be70a1ac-bde9-4e49-89e7-b49d6398a15b" />
<img width="2104" height="995" alt="image" src="https://github.com/user-attachments/assets/cbfc08fe-b640-476c-9f85-49da59ebe438" />
<img width="2721" height="1480" alt="image" src="https://github.com/user-attachments/assets/71650999-e7f3-4003-a055-eee6c9c8b547" />
<img width="2672" height="1046" alt="image" src="https://github.com/user-attachments/assets/4340e54f-5e3a-459e-94a0-a1d4e9fd57c9" />
<img width="2660" height="1063" alt="image" src="https://github.com/user-attachments/assets/f04ef6a3-4ce2-417a-b30b-6c183dc13de8" />


## CORS Scenarios
<img width="2058" height="1013" alt="image" src="https://github.com/user-attachments/assets/7853537c-8f25-4c72-a26f-4be77e37f2f1" />
<img width="2049" height="1001" alt="image" src="https://github.com/user-attachments/assets/2ac31512-b95f-4bc6-8a18-7152c05f3eab" />D
<img width="1846" height="1056" alt="image" src="https://github.com/user-attachments/assets/9eea7f62-3b3f-4c9f-a03a-594bb9f7a064" />
<img width="2052" height="1148" alt="image" src="https://github.com/user-attachments/assets/4e0d63bf-2464-469d-876e-a3d7573cdefc" />

<img width="1934" height="821" alt="image" src="https://github.com/user-attachments/assets/41f22731-d006-45b2-87a3-8b195f2d6dba" />
when method type option that is a pre-flighted request
<img width="1984" height="1088" alt="image" src="https://github.com/user-attachments/assets/fc082ee6-1183-4638-8b0c-5df43158694b" />
<img width="2008" height="1120" alt="image" src="https://github.com/user-attachments/assets/a35b11f9-5111-4e8f-a82b-1e4c68e9e9e5" />
main request will cancel


## Enabling CORS in Web API using middleware

#### Allow all origin
<img width="1758" height="572" alt="image" src="https://github.com/user-attachments/assets/5f5ff342-04a3-4625-9958-37484894212c" />
<img width="1598" height="656" alt="image" src="https://github.com/user-attachments/assets/0f5eb247-679b-4298-a0c9-c79c239bf334" />
<img width="1772" height="772" alt="image" src="https://github.com/user-attachments/assets/4cd5013d-1174-4ccb-b2d3-af28fc4eea4b" />


#### Allow only few origin
<img width="1586" height="418" alt="image" src="https://github.com/user-attachments/assets/7a555176-6469-4cc5-a053-99b326337af3" />
<img width="1978" height="862" alt="image" src="https://github.com/user-attachments/assets/93d5661d-ab82-4c10-a3ff-621071ba3559" />


## Web API Security Using JWT Authentication

<img width="1812" height="566" alt="image" src="https://github.com/user-attachments/assets/33079384-1daf-410b-9977-1e030e66cd0b" />
<img width="1787" height="568" alt="image" src="https://github.com/user-attachments/assets/c18de28f-715d-4373-9519-5df260a70db0" />
<img width="1830" height="821" alt="image" src="https://github.com/user-attachments/assets/da031d31-5774-4f96-a6b8-7c353f2ba288" />

<img width="1941" height="964" alt="image" src="https://github.com/user-attachments/assets/d4921458-e536-4dcb-be5c-09f1847df3ac" />

#### JWT token have three things Header, Payload and Signature
- :rocket: It's also possible sometime jwt doesn't contain the signature that we call it jwt is not secured
<img width="1958" height="1084" alt="image" src="https://github.com/user-attachments/assets/b808dd30-2fea-49e3-8b00-8d350a3d8d9f" />

🚀 Header mainly use for what algorithm use to validate and encript the token and another this Type 
<img width="1953" height="956" alt="image" src="https://github.com/user-attachments/assets/d910d56f-670b-4b01-9a4f-10de10f780de" />

🚀We can pass empty payload as well
<img width="1962" height="833" alt="image" src="https://github.com/user-attachments/assets/2aab0106-ba54-47e4-a3ed-24bd24262cd5" />

🚀JWT-Signature
<img width="1970" height="961" alt="image" src="https://github.com/user-attachments/assets/40cdf9f8-f7e8-42dc-ba07-ef78883472b1" />

🚀 Base64 encoded is important here 👿
<img width="1969" height="781" alt="image" src="https://github.com/user-attachments/assets/b7dff50b-ec97-45e7-8dfe-72c22ddbd147" />

🚀Token Generation
<img width="2856" height="1545" alt="image" src="https://github.com/user-attachments/assets/af562af1-5938-4739-8a25-943aa660a0e9" />

✅ What is the Signature?
  The signature is created by signing the header and payload using a secret (or private key) and a signing algorithm (e.g., HMAC SHA256).
<pre> ``` HMACSHA256(
  base64UrlEncode(header) + "." + base64UrlEncode(payload), 
  secret_key
) ``` </pre>

📌 Purpose of the Signature:
- Verify the token’s authenticity – ensures it was issued by a trusted source.
- Detect tampering – if the payload or header is changed, the signature won't match, so the token is invalid.
- Secure data transmission – although JWTs are not encrypted by default, the signature ensures data wasn't altered

<img width="1990" height="1117" alt="image" src="https://github.com/user-attachments/assets/ab2557ce-5217-446f-b89c-562402e215dd" />


#### Algorithms used in JWT

<img width="1802" height="915" alt="image" src="https://github.com/user-attachments/assets/16478ad8-18bc-407f-967e-961226dc87c3" />

<img width="1797" height="815" alt="image" src="https://github.com/user-attachments/assets/bdc0ecc6-4d25-4c1c-9c19-467cb0e3541c" />


<img width="2099" height="817" alt="image" src="https://github.com/user-attachments/assets/9bbda956-828d-498a-899c-38e128274d23" />

### If we add [Authorize] annotation add to controller  we are making it sequre end points

<img width="2023" height="617" alt="image" src="https://github.com/user-attachments/assets/a77bb891-fc8c-494e-8ada-204a9d8c4cf3" />

#### if we don't want's any restriction
<img width="2080" height="1018" alt="image" src="https://github.com/user-attachments/assets/93c5ec5c-e955-4c66-aada-b3e9b211eff2" />

| Method     | Use When                       |
| ---------- | ------------------------------ |
| `Roles`    | Simple admin/user separation   |
| `Policies` | When you need to combine rules |
| `Claims`   | When identity has rich data    |
| `Handlers` | For complex, contextual logic  |


### Sectret key reading from config
<img width="1885" height="528" alt="image" src="https://github.com/user-attachments/assets/b11897fb-69fa-41e8-b6ee-05064e1c40dd" />
<img width="2761" height="1180" alt="image" src="https://github.com/user-attachments/assets/fb813642-f2ff-4439-b6e8-f102ee466399" />


### Pre-requisites for JWT
1. Microsoft.AspNetCore.Authentication.JwtBearer

#### This controler is sequre now and here we have allowed admin and Superadmin to access this aplication
<img width="916" height="378" alt="image" src="https://github.com/user-attachments/assets/a762ba14-f8f9-4aa9-81bb-c45a6ebcdd3c" />

#### [AllowAnonymous]
This method only allow this particular method access without any authentication
<img width="994" height="278" alt="image" src="https://github.com/user-attachments/assets/f676b4d2-a718-4969-951c-5462874b2b8b" />\


#### Part 72 Configuring Web API to use JWT
<img width="1704" height="930" alt="image" src="https://github.com/user-attachments/assets/8efc23fa-9cb0-4aa3-ad3d-988c95cc656e" />

📓 Note: the above we are getting 500 error
*** we can add jwt in two diff way 
DEFAULT and NAME way.

##### Default: -😃
<img width="1239" height="376" alt="image" src="https://github.com/user-attachments/assets/40b50031-458a-49a5-9e47-a310b4380db0" />
<img width="1326" height="524" alt="image" src="https://github.com/user-attachments/assets/7388db7f-6549-4540-90e8-dd10f6ee2879" />

📓Note: now after registering token in program file we are getting 401(unauthorize)



## 73 Generating JWT token
we have to total 5 step
### Validate the Input(1)
If the user didn’t send username/password, return 400 BadRequest.
### Check Credentials(2)
* For demo, we hardcoded admin/password123
* In real projects, validate against database or ASP.NET Identity.
* If wrong → return 401 Unauthorized.
### Create Claims(3)
* Claims are user-related info stored inside the token
* Example: username, unique ID, role.
* Later you can read them in secured endpoints.

<pre>var claims = new[]
{
    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    new Claim("role", "Admin")
};</pre>

### Generate Security Key & Credentials(4)
* A secret key (_jwtSecret) is used to sign the token.
* It must be long, random, and stored safely (usually in appsettings.json).
<pre> var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JWTSecret")) ;
 var creds=new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256);</pre>

### Build the JWT Token(5)
* JwtSecurityToken is created with:
      * `issuer` & `audience` → who created & who can use it.
      * `claims` → user info.
      * `expires` → when token becomes invalid.
      * `signingCredentials` → to prevent tampering.
  <pre>var token = new JwtSecurityToken(issuer: "yourapp.com",audience: "yourapp.com",claims: claims,expires: DateTime.UtcNow.AddHours(1), // token validitysigningCredentials: creds);</pre>

### Return the Token(6)
* Return 200 OK with `token` and `expiration`.
* The frontend will store this token (usually in localStorage or cookies).

<img width="972" height="828" alt="image" src="https://github.com/user-attachments/assets/390d8151-8862-487e-a7f7-f5245541dad8" />

<img width="1078" height="863" alt="image" src="https://github.com/user-attachments/assets/1b456edb-94a1-451f-b91b-c1168555d160" />


## Configure authentication in Swagger
<img width="949" height="537" alt="image" src="https://github.com/user-attachments/assets/91f9012e-c085-4fcf-b81e-b704e4683874" />


```csharp
options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
```
* Registers a Swagger/OpenAPI document named v1.

* Displays title/version in Swagger UI.

```csharp
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { ... });
```
* Adds a named security definition called "Bearer".
* Defines how users will supply credentials in the UI.

### Inside the `OpenApiSecurityScheme`

- **Name = "Authorization"**  
  The HTTP header name Swagger sets. Must match what your API expects (usually `Authorization`).

- **Type = SecuritySchemeType.ApiKey**  
  Means the credential is passed as a header or query parameter.  
  ⚠️ Alternative (preferred for JWT): `SecuritySchemeType.Http` with `Scheme = "bearer"`.

- **Scheme = "Bearer"**  
  Metadata about scheme. If using `Http`, set this to `"bearer"` (lowercase).

- **BearerFormat = "JWT"**  
  Documentation hint that the token is a JWT. No functional effect.

- **In = ParameterLocation.Header**  
  Specifies that the credential goes into the HTTP header.

- **Description**  
  Message shown in Swagger’s **Authorize** dialog.  
  Example: `Bearer 12345abcdef`.  
  Important to clarify whether users should paste the token only, or the token prefixed with `"Bearer "`.  


```csharp
options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});
```
* Declares that the "Bearer" security definition is required.
* Applied at the document level → Swagger UI enforces this for all operations.
* The empty string array is for OAuth scopes (not used here).
* Effect: Enables the Authorize button in Swagger UI. After authorization, Swagger attaches the JWT header automatically to all requests.


## Multiple JWT Authentication in ASP.NET Core Web API
📌 Purpose
* Sometimes an API needs to accept tokens from multiple issuers or clients.
- Example scenarios:
-  * Supporting different applications with separate keys.
   * Migrating from an old identity provider to a new one.
   * Allowing internal vs external authentication sources.
* Multiple JWT schemes let you configure different validation rules (issuer, audience, signing key) within the same API.

  
⚙️ Configuration
#### 1. Add authentication with multiple schemes
```csharpusing Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load keys from configuration
var jwtKey1 = Encoding.UTF8.GetBytes(builder.Configuration["JWTSecret1"]);
var jwtKey2 = Encoding.UTF8.GetBytes(builder.Configuration["JWTSecret2"]);

builder.Services.AddAuthentication()
    .AddJwtBearer("Scheme1", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "issuer1.com",
            ValidateAudience = true,
            ValidAudience = "audience1",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey1),
            ValidateLifetime = true
        };
    })
    .AddJwtBearer("Scheme2", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "issuer2.com",
            ValidateAudience = true,
            ValidAudience = "audience2",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey2),
            ValidateLifetime = true
        };
    });

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

#### 2. Use [Authorize] with a specific scheme

```csharp [Authorize(AuthenticationSchemes = "Scheme1")]
[HttpGet("data-from-scheme1")]
public IActionResult GetDataFromScheme1() => Ok("Valid Scheme1 token");

[Authorize(AuthenticationSchemes = "Scheme2")]
[HttpGet("data-from-scheme2")]
public IActionResult GetDataFromScheme2() => Ok("Valid Scheme2 token");
```
* If no scheme is specified, the default scheme applies.
* If multiple schemes are required, you can pass a comma-separated list:
   ```csharp [Authorize(AuthenticationSchemes = "Scheme1,Scheme2")]```

#### 🔑 Important Notes
* Each scheme can have its own issuer, audience, signing key, and lifetime rules.
* Good practice: name schemes clearly (e.g., InternalAuth, ExternalAuth) instead of "Scheme1".

  <img width="1058" height="316" alt="image" src="https://github.com/user-attachments/assets/0d5477d7-f19d-4711-a793-0a9cd0ba90fb" />
  <img width="1132" height="864" alt="image" src="https://github.com/user-attachments/assets/881df26e-3f9d-4d52-8ca1-bfaae2b1584f" />
  <img width="1026" height="382" alt="image" src="https://github.com/user-attachments/assets/d9e6fe45-0cf2-4640-8836-030aea4d333c" />
  <img width="1118" height="862" alt="image" src="https://github.com/user-attachments/assets/756f5aed-ae27-4b1e-aad6-2f32319b62d0" />
  <img width="1060" height="432" alt="image" src="https://github.com/user-attachments/assets/e22935ad-772f-46c5-b88c-182eab2b4c96" />
  <img width="1112" height="498" alt="image" src="https://github.com/user-attachments/assets/39ad4fac-9a25-48f4-bf49-4748f4d69511" />





 
 








