This is a c# port of Jov Mit's live coding at the 1st international TDD conference.

[Jov's original presentation](https://www.youtube.com/watch?v=pmsql3qOmNA)

Follow along using git commits.

## Live Demo with git

### Prerequisites

- add `next` and `prev` git aliases as described
  [here](https://blog.jayway.com/2015/03/30/using-git-commits-to-drive-a-live-coding-session/)
- TLDR:

```git
[alias]
next = !git checkout `git rev-list HEAD..demo-end | tail -1`
prev = checkout HEAD^
```

### Workflow

- `git clone` ...
- `cd` ...
- `git checkout demo-start`
- `git next` / `git prev`
- when done: `git checkout main`

