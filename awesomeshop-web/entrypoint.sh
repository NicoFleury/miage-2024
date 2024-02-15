#!/bin/sh
set -xe
: "${API_URL?API_URL mandatory}"
: "${KEYCLOAK_URL?KEYCLOAK_URL mandatory}"

for i in main*.js; do
    cat $i | sed -e "s|%API_URL%|$API_URL|g" | sed -e "s|%KEYCLOAK_URL%|$KEYCLOAK_URL|g" > /tmp/script-$i
    cat /tmp/script-$i > $i
done

exec "$@"