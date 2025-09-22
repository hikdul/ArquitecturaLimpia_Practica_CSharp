# Leeme Por Favor

Aca escondere algunos comando que son necesarios para trabajar con este proyecto y donde incleso existen cosas que van mas aya y son del trabajo de Dotnet en arch

### dotnet ef se pierde


En ocasiones o mejor dicha cada ves que se usa un terminal, dotnet-ef como que no se consigue. por tanto se debe de ejecutar el siguiente comando

```
export PATH="$PATH:$HOME/.dotnet/tools/"
```

### Problema de ICU + Could no find a valid ICU Package


En ocasiones el sistema genera un erro donde al ejecutar migracione y cosas asi indica algo de ICU package instaler, esto se soluciona con el siguiente comando:
```
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
```
el error que me aparecia a mi rezaba algo como:
```

```

## Generar una migracion


Para generar una migarcion se puede usar el siguiente comando. Recuerde que las migraciones se ejecutan desde la capa de persistencia en infraestructura

```
 dotnet ef migrations add TablaPacientesMigration --startup-project ../../API/DientesLimpios.API/DientesLimpios.API
```