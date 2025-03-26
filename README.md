1) Перед началом работы нужно из папки Finstar.Infrastructure запустить    
   rh --connectionstring="Data Source=localhost;Initial Catalog=Finstar;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;Integrated Security=True;" --sqlfilesdirectory="Migrations"
2) фронтенд и бэкенд запускаются отдельно из папок frontend (npm start) и backend соответственно 