import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'LowCodeDevelopmentPlatform',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44395',
    redirectUri: baseUrl,
    clientId: 'LowCodeDevelopmentPlatform_App',
    responseType: 'code',
    scope: 'offline_access LowCodeDevelopmentPlatform',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44395',
      rootNamespace: 'LowCodeDevelopmentPlatform',
    },
  },
} as Environment;
