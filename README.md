# Opi Reports – Generación de Reportes PDF

API en .NET 8 con QuestPDF y Clean Architecture

## Descripción del Proyecto

Opi Reports es una API diseñada para recibir información generada por un proceso RPA y convertirla en un reporte PDF estructurado, utilizando QuestPDF como motor de renderizado.
El objetivo es sustituir la generación actual basada en Excel, evitando fallas de formato, páginas truncadas y procesos manuales.

El proyecto implementa Clean Architecture para lograr una estructura mantenible, escalable y separada por responsabilidades.

---

## Arquitectura del Proyecto

### Domain

* Contiene las entidades principales del negocio.
* No depende de ninguna otra capa.
* Modelo puro sin lógica de infraestructura.

### Application

* Define interfaces, DTOs y casos de uso (Commands y Queries con MediatR).
* Implementa la lógica de aplicación sin depender de detalles técnicos.
* Solo depende de Domain.

### Infrastructure

* Implementa las interfaces declaradas en Application.
* Contiene la lógica de acceso a datos y la generación del PDF.
* Incluye la clase `InfrastructureServiceRegistration` para registro en DI.

### API

* Expone los controladores y ejecuta los casos de uso.
* Configura la inyección de dependencias, Swagger y middlewares.
* Proyecto ejecutable.

---

## Flujo General

1. El proceso RPA obtiene la información desde Excel o desde sus macros.
2. La RPA envía un cuerpo JSON a la API.
3. La API recibe el modelo y lo envía al caso de uso correspondiente.
4. La capa Application valida y envía la información a Infrastructure.
5. Infrastructure genera el PDF con QuestPDF.
6. La API devuelve el PDF como archivo o como Base64 para su consumo por la RPA.

---

## Endpoints Principales

### POST /api/reports

Genera un reporte a partir del JSON enviado.

#### Ejemplo de cuerpo:

```json
{
  "title": "Monitoreo de Equipo Base - Octubre",
  "reportDate": "2025-10-25",
  "rows": [
    {
      "assignedTo": "Transversal Icetex",
      "role": "",
      "project": "Transversal Icetex",
      "reportDate": "2025-10-01",
      "description": "Gestión de reporte de actividades diarias",
      "plannedHours": 0.25,
      "realHours": 0.25
    }
  ]
}
```

#### Respuesta

* PDF generado en Base64 o archivo binario.

---

## Tecnologías Utilizadas

* .NET 8
* QuestPDF 2024
* Clean Architecture
* MediatR
* Swagger / OpenAPI
* Integración con RPA (UiPath, Power Automate, BluePrism o equivalente)

---

## Ejecución del Proyecto

Restaurar dependencias:

```
dotnet restore
```

Compilar:

```
dotnet build
```

Ejecutar la API:

```
dotnet run --project src/Opi.Reports.API
```

Abrir Swagger:

```
http://localhost:5000/swagger
```

---

## Estructura del Repositorio

```
/src
  /Opi.Reports.Domain
  /Opi.Reports.Application
  /Opi.Reports.Infrastructure
  /Opi.Reports.API

/tests
  (opcional para pruebas unitarias)
```

---

## Estado Actual del Proyecto

* Definición de modelos principales.
* Implementación de casos de uso CRUD.
* Ajuste del generador PDF con QuestPDF.
* Preparación para integración con el proceso RPA.
