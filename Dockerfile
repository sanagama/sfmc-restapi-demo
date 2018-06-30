#
# A simple REST API demo for Salesforce Marketing Cloud
# June 2018
#

FROM microsoft/aspnetcore-build:latest
LABEL author="Sanjay Nagamangalam <sanagama2@gmail.com>"
LABEL version=1.0

# Environment variables
# Chaining the ENV allows for only one layer, instead of one per ENV statement
ENV HOMEDIR=/sfmc-restapi-demo

# Web API listens at http://localhost:5000 in container
EXPOSE 5000

# Copy web app directory to image
RUN mkdir -pv $HOMEDIR
WORKDIR $HOMEDIR
COPY . $HOMEDIR

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
CMD ["dotnet", "run"]
