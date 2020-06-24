import { 
  configuration, 
  DefaultMarkdownCustomComponents
} from '@codedoc/core';
import { codingBlog } from '@codedoc/coding-blog-plugin';

import { theme } from './theme';
import { Utterances } from './components/utterances';



export const config = /*#__PURE__*/configuration({
  theme,
  src: {
    base: 'src/markdown'
  },
  dest: {
    html: 'dist',
    assets: '.', // TODO: want 'src/assets' but blocked by https://github.com/CONNECT-platform/coding-blog/issues/18
    bundle: 'bundle',
    styles: 'styles',
  },
  page: {
    title: {
      base: ''
    },
    favicon: 'src/assets/favicon.ico',
    meta: {
      subject: 'Blog of Tyson Williams',
      description: 'Blog by Tyson Williams about software development and functional programming',
      keywords: ['software', 'development', 'functional', 'programming', 'Tyson', 'Williams'],
    },
  },
  plugins: [
    codingBlog({
      assets: [
        'src/assets/images',
        'src/assets/favicon.ico',
      ]
    })
  ],
  markdown: {
    customComponents: {
      ...DefaultMarkdownCustomComponents,
      Utterances
    }
  },
  misc: {
    github: {
      repo: 'coding-blog-boilerplate',
      user: 'CONNECT-platform'
    }
  }
});
