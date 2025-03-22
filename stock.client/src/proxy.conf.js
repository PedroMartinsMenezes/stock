const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7292';

const PROXY_CONFIG = [
    {
        context: [
            "/weatherforecast",

            "/produto/list",
            "/produto/getById",
            "/produto/create",
            "/produto/update",
            "/produto/delete",

            "/movimentacao/list",
            "/movimentacao/getById",
            "/movimentacao/create",
            "/movimentacao/update",
            "/movimentacao/delete",

            "/relatorio/getEstoque",
        ],
        target,
        secure: false
    }
]

module.exports = PROXY_CONFIG;
