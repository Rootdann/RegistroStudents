Username: admin, Password: admin123
Username: usuario, Password: usuario123


# Sistema de Registro de Estudiantes

Un sistema web completo para la gestión y registro de estudiantes desarrollado con ASP.NET Core 9.0, Entity Framework Core y SQLite.

## 📋 Características

- **Autenticación de usuarios**: Sistema de login seguro con cookies
- **Gestión de estudiantes**: Registro, visualización, edición y eliminación de estudiantes
- **Base de datos SQLite**: Almacenamiento ligero y portable
- **Interfaz responsive**: Diseño adaptable a dispositivos móviles y escritorio
- **Temas personalizables**: Soporte para tema claro/oscuro y diferentes colores
- **Dockerizado**: Listo para desplegar en cualquier entorno compatible con Docker

## 🚀 Tecnologías utilizadas

- **Backend**: ASP.NET Core 9.0, Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **Base de datos**: SQLite
- **Contenedorización**: Docker
- **Despliegue**: Compatible con Render

## 🔧 Instalación y ejecución local

### Requisitos previos
- .NET 9.0 SDK o superior
- Git (opcional)

### Pasos para ejecutar localmente
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/StudentRegistrationSystem.git
   cd StudentRegistrationSystem
   ```

2. Restaurar paquetes y compilar:
   ```bash
   dotnet restore
   dotnet build
   ```

3. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador:
   ```
   https://localhost:5001
   ```

## 🐳 Ejecución con Docker

1. Construir la imagen:
   ```bash
   docker build -t student-registration-system .
   ```

2. Ejecutar el contenedor:
   ```bash
   docker run -p 8080:8080 student-registration-system
   ```

3. Acceder a la aplicación:
   ```
   http://localhost:8080
   ```

## 📦 Estructura del proyecto

```
StudentRegistrationSystem/
├── Controllers/         # Controladores MVC
├── Data/                # Contexto de base de datos y migraciones
├── Models/              # Modelos de datos y ViewModels
├── Views/               # Vistas Razor
├── wwwroot/             # Archivos estáticos (CSS, JS, imágenes)
├── Dockerfile           # Configuración para Docker
├── Program.cs           # Punto de entrada y configuración
└── appsettings.json     # Configuraciones de la aplicación
```

## 🌐 Despliegue en Render

Este proyecto está optimizado para ser desplegado en Render utilizando Docker:

1. Crear un nuevo Web Service en Render
2. Seleccionar "Deploy from GitHub repo"
3. Conectar con el repositorio
4. Seleccionar "Docker" como Runtime
5. Configurar las variables de entorno necesarias
6. Hacer clic en "Create Web Service"

## 🔐 Autenticación

El sistema utiliza autenticación basada en cookies con las siguientes características:
- Rutas de login/logout configuradas
- Cookies HTTP-only para mayor seguridad
- Expiración de sesión configurable (7 días por defecto)
- Redirección a login para usuarios no autenticados

## 📝 Modelo de datos

### Estudiante
- **Id**: Identificador único
- **Nombre**: Nombre completo del estudiante (requerido, máx. 100 caracteres)
- **Edad**: Edad del estudiante (entre 1 y 100)
- **Curso**: Curso al que pertenece (requerido, máx. 50 caracteres)
- **Promedio**: Calificación promedio (entre 0 y 10)

## 🎨 Personalización de temas

El sistema permite personalizar:
- Tema claro/oscuro (con detección automática de preferencias del sistema)
- Colores de acento (azul, verde, rojo, naranja, púrpura)
- Preferencias guardadas en localStorage

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo LICENSE para más detalles.

## 👨‍💻 Autor

Tu Nombre - [tu-usuario](https://github.com/tu-usuario)

---

⭐️ Si te gusta este proyecto, ¡no olvides darle una estrella en GitHub! ⭐️
