migrate:
	dotnet ef migrations add $(name) \
		--project ./Stockly.Infra/Stockly.Infra.csproj \
		--startup-project ./Stockly.Api/Stockly.Api.csproj \
		--output-dir Migrations

update-db:
	dotnet ef database update \
		--project ./Stockly.Infra/Stockly.Infra.csproj \
		--startup-project ./Stockly.Api/Stockly.Api.csproj
