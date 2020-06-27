import { join } from 'path';
import { serve } from '@codedoc/core';

import { config } from './config';
import { content } from './content';
import { installTheme$ } from './content/theme';


const root = join(__dirname, '../');

serve(root, config, content, installTheme$, {
  module: {
    rules: [
      {
        test: /\.js$/,
        enforce: 'pre',
        use: ['source-map-loader'],
      },
    ],
  },
  resolve: {
    modules: ['.codedoc/node_modules']
  },
  resolveLoader: {
    modules: ['.codedoc/node_modules']
  }
});
