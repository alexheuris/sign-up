#!/bin/bash

sleep 15s
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P myPASSWORD123 -d master -i setup.sql
