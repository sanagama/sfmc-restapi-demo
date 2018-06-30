#!/bin/bash

set -x

docker build . -t sanagama/sfmc-restapi-demo

docker images

docker push sanagama/sfmc-restapi-demo

