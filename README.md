# ASPNetCoreApp.NLog.RabbitMQ

## Overview

[![Build Status](https://dev.azure.com/raulsr/Labs/_apis/build/status/ruglax.ASPNetCoreApp.NLog.RabbitMQ?branchName=master)](https://dev.azure.com/raulsr/Labs/_build/latest?definitionId=2&branchName=master)

El proyecto tiene como finalidad realizar una integración básica de RabbitMQ como soporte de almacenamiento de logs.

### Prerequisitos

* Se debe tener instalado RabbitMQ https://www.rabbitmq.com/install-windows.html. Se recomienda habilitar el plugin Management UI Access.
Para habilitar el plugin se de realizar los siguientes pasos:
	1. Abrir una consola con permisos de administrador.
	2. Navegar a la ruta **sbin** en el directorio de instalación de RabbitMQ generalmente ubicada en:  "*C:\Program Files\RabbitMQ Server\rabbitmq_server-3.8.0\sbin*"
	3. Ejecutar el comando para habilitar el plugin Management UI Access "`rabbitmq-plugins enable rabbitmq_management`" 
