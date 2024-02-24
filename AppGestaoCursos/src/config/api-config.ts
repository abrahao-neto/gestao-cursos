export const API_CONFIG = {
  // Defina a configuração desejada para BASE_API comentando/descomentando as linhas apropriadas
  BASE_API: 'local',
  // BASE_API: 'desenvolvimento',
  // BASE_API: 'homologacao',
  // BASE_API: 'producao',

  UrlApiLocal: 'http://localhost:5180/',
  UrlApiDesenvolvimento: '',
  UrlAplHomologacao: '',
  UrlApiProducao: '',

  getBaseUrl(): string {
    switch (this.BASE_API) {
      case 'local':
        return this.UrlApiLocal;
      case 'desenvolvimento':
        return this.UrlApiDesenvolvimento;
      case 'homologacao':
        return this.UrlAplHomologacao;
      case 'producao':
        return this.UrlApiProducao;
      default:
        return 'http://localhost:5180/';
    }
  },
};
