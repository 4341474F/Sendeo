# Sendeo

## Getting Started

Sendeo is an online shop. They would like to share the orders with an API to third party applications. Order information should also include customer and product details. There are 3 microservices which are Order, Product and Customer microservices leveraging RESTful API NET6, EF Core, CQRS, Docker, RabbitMQ tha retruns orders fulfilled within the given date range in the order microservice. Use .. Please note the stress is on microservices approach and test coverage.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/4341474F/Sendeo.git
   ```
## Usage

When pull the projects this is the project folder you should see :

![image](https://user-images.githubusercontent.com/19145921/210164814-77e336be-7481-4c6f-8726-a84d5b7850dd.png)

First enter the root directory Sendeo, there is a docker-compse.yaml file, open the terminal and run this command:
  
  * docker-compose up
  
 After running succesfully, you should have 6 docker container up which are;
  * sendeo-db           : Container running MS SQL Server 2022 inside of it responsible for DB
  * rabbitmq            : Container running RabbitMq message broker inside of it responsible for Message Que
  * ApiGateway          : Container running Ocelot Api gateway 2022 inside of it responsible for messaging between the microservices as a api gateway
  * CustomerService.API : Container running ASP.NET Core Web API using .Net 6.0 inside of it responsible for Customer microservice
  * OrderService.API    : Container running ASP.NET Core Web API using .Net 6.0 inside of it responsible for Order microservice
  * ProductService.API  : Container running ASP.NET Core Web API using .Net 6.0 inside of it responsible for Product microservice
   
