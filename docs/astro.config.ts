// @ts-check
import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';
import starlightThemeBlack from '@hecatron/starlight-theme-black'
import starlightAutoDrafts from 'starlight-auto-drafts';
import { generateSidebarGroups } from './src/sidebar_grps.mjs';

// https://astro.build/config
export default defineConfig({
  site: 'https://htronic-templates.github.io/dotnet-desktoptemplate-blazor/',
  base: '/dotnet-desktoptemplate-blazor',
  integrations: [
    starlight({
      title: 'dotnet-desktoptemplate-blazor',
       logo: {
        dark: './src/assets/logo-dark.svg',
        light: './src/assets/logo-light.svg',
        alt: 'Template Docs Page',
      },
      social: [{ icon: 'github', label: 'GitHub', href: 'https://github.com/htronic-templates/dotnet-desktoptemplate-blazor' }],
      customCss: [
        './src/styles/themes/theme-deep-purple.css',
      ],
      editLink: {
        baseUrl: 'https://github.com/htronic-templates/dotnet-desktoptemplate-blazor/edit/master/docs/',
      },
      plugins: [
        starlightThemeBlack({
          navLinks: [
            {
              label: 'API',
              link: '/getting-started/api',
            },
          ],
        }),
        starlightAutoDrafts(),
      ],
    }),
  ],
});
