# DevOps

## Essential

To locally host this site, clone this repo, execute
```
npm i -g @codedoc/cli
codedoc install
```

to obtain all depenencies, and then execute
```
codedoc serve
```

to begin serving the website at [localhost:3000](http://localhost:3000).

## Additional

There are some [dependencies of `codedoc/cli`](https://codedoc.cc/docs/cli#cli) that might need to be installed first.

One dependency of `codedoc/cli` is `codedoc/core`.  Check the versions of these two by executing `codedoc -v`.  Update `codedoc/core` to the latest version by executing `codedoc update latest --local` (c.f. [this issue](https://github.com/CONNECT-platform/codedoc/issues/22)).

If port 3000 is being used, then a different one can be specified in the [configuration](https://codedoc.cc/docs/config/overview#available-properties).

# Acknowledgements

I could not have created this blog without all the help I received.

## Technologies

These wonderful technologies are used to make this site.

### [`coding.blog`](https://coding.blog)

This blog is primarily powered by the [CONNECT-platform](https://github.com/CONNECT-platform).  It is deployed and hosted by [`coding.blog`](https://coding.blog) and most of the markdown features come from [CODEDOC](https://codedoc.cc/).

I was fortunate to be granted early access to `coding.blog`.  If you would like a blog like this, then go [here](https://coding.blog/#how-to-get-there) and join their Prospective Creators List.

Eventually, you can financially support `coding.blog` in exchange for a personally curated content feed.  For now, you can go [here](https://coding.blog/#how-to-get-there) and join their Waiting List for Beta.

### [utterances](https://utteranc.es/)

Support for comments on posts is powered by utterances.  The comments are stored in post-specific issues in this GitHub repo.  Anyone with a GitHub account can add a comment.  If you authorize the utterances bot to post on your behalf, then you can add a comment directly from the post.  Otherwise, you can simply navigate from the post to the backing issue using the link provided above the first comment and post there yourself.

### GitHub

Of course GitHub also plays a crucial role.  In addition to hosting the comments in select issues, all the content is committed into this repo.  The website is redeployed shortly after `master` is updated.

# Improvements?

Is there some improvement that you would like to see in my blog?  You can tell me about it by [creating an issue](https://github.com/bender2k14/tyson-williams-blog/issues/new) or you can make the improvement yourself and then send me a [pull request](https://github.com/bender2k14/tyson-williams-blog/compare).