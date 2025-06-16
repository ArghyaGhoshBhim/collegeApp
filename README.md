# Content negotiation in Web/REST API:
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











   
 
 








