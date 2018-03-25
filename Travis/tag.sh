#! /bin/sh

if [ "$TRAVIS_BRANCH" == "master" ]; then
  git config --local user.name "traviscibot"
  git config --local user.email "traviscibot@travisci.org"
  git tag "v$(date +'%Y.%m.%d.%H%M')"
fi