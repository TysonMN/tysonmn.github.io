import { themedStyle } from '@connectv/jss-theme';
import { CodedocTheme } from '@codedoc/core';


export const UtterancesStyle = themedStyle<CodedocTheme>(_ => ({
utterancesTransparentIframe: {
   '& iframe.utterances-frame': { background: 'transparent' },
 }
}));