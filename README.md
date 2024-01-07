# Happy Paws 🐾

**Our project is a Heartwarming Pet Adoption Platform! 🐾**  

Registered users have the opportunity to adopt homeless companions seeking loving homes, or they can welcome a new friend into their lives. The unique identification details of animals can be viewed by users, making it easier than ever to connect with these special beings.🌟     
Additionally, veterinarian-approved health records 🏥 secure the well-being of each friend and provide users with instant information. This platform not only facilitates the adoption process but also opens the doors to a life filled with love and responsibility.💖   
To create a more beautiful world together, open the doors of your heart and invite a companion into your life! 🌍🐶✨  
# Team 6 Happy Paws Project
- This repository contains the Happy Paws project provided by YetGen Jump & Akbank Backend Education Program. 
- The details of the project, which we completed as Team 6, are provided below: ⇓

## Ozge's part [![Ozge](https://img.shields.io/badge/Ozge-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/ozgedincer)
- The inception of the database design aimed at precisely understanding the project's requisites and establishing a comprehensive framework. A critical aspect involved in this process was the definition of data types and constraints, pivotal for guaranteeing the integrity of the data. The primary focus throughout was on creating a customized database meticulously aligned with the project's specifications.
  
- The foundational structure of the project has been successfully established with entity, common, and enum structures, and the initial stages of the project have been completed successfully.
  
- FluentValidation has been added to the created models, ensuring that users adhere to specific rules when registering in the system.
  
- In our project, I implemented the CQRS pattern using MediatR to enhance the overall architecture. This involved a significant code restructuring to clearly distinguish between commands, responsible for modifying the system's state (e.g., creating, updating, or deleting data), and queries, which handle data retrieval.
With the integration of MediatR, I established a mediator responsible for facilitating communication between different components of the system. This mediator efficiently dispatches commands or queries to their designated handlers, fostering a more organized and maintainable codebase.
The incorporation of CQRS with MediatR has brought notable improvements to our project. The clear separation of concerns has not only made the codebase more scalable but also enhanced its maintainability and overall comprehensibility.


## Zahide's Part  [![Zahide](https://img.shields.io/badge/Zahide-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/zahidedusgun)
- The foundational structure of the project has been successfully established with entity, common, and enum structures, and the initial stages of the project have been completed successfully. Particularly, the Identity Mechanism has been meticulously written in the Domain Area, and the User table has been activated, facilitating the integration of users into the system.

- Models necessary for authentication processes have been effectively created in the Model folder of the API, and these models have been implemented in the AuthController file. Additionally, FluentValidation has been added to the created models, ensuring that users adhere to specific rules when registering in the system. This is a crucial step for the security and data integrity of the system.

- The hashing process for passwords during user registration has been successfully completed. This is a critical security measure that enables users to integrate into the system securely.

- Furthermore, the JWT Token system, which provides tokens to users logging into the system, has been successfully implemented. This facilitates secure user authentication and makes it easier for users to access and use the system.

## Hatice's Part [![Hatice](https://img.shields.io/badge/Hatice-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/hatice-dvc)
- In this project, I defined the EntityBase class under the Common folder, which entities under the Common folder can inherit from. Additionally, I defined necessary classes such as ICreatedByEntity.

- I created the Adopter Entity, which holds individuals adopting animals, and the AdopterController. CRUD operations are performed through the AdopterController.

- To utilize the desired features of adopters through Swagger, I created CreateAdopterCommandHandler, CreateAdopterCommandRequest, and CreateAdopterCommandResponse classes under the Features folder. I used the MediatR library in these classes. In addition to the create operations, I also implemented the classes for remove and update requests.

- Alongside the Commands feature, I added Queries for Adopter. I added the ability to view all adopters through the GetAllAdopterQueryHandler and the ability to find an adopter by Id through the GetByIdAdopterQueryHandler.

## Bahar's Part  [![Bahar](https://img.shields.io/badge/Bahar-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/baharerol)
- Initially, we conducted the requirements analysis and visually designed the entities and database relationships for the project.

- The foundational structure of the project has been successfully established with entity, common, and enum structures, and the initial stages of the project have been completed successfully.

- FluentValidation has been added to the created models, ensuring that users adhere to specific rules when registering in the system.

- In our project, I implemented the CQRS pattern for the HealthRecord entity.

  Command Query Responsibility Segregation (CQRS) pattern separates the data mutation, or the command part of a system, from the query part. You can use the CQRS pattern to separate updates and queries if they have different requirements for throughput, latency, or consistency.

- I created separate files in the Applications layer for commands and queries, including Response, Request, and Handler classes.

- While applying the CQRS pattern, I utilized the MediatR library. I designed the HealthRecordsController using the MediatR library and implemented CRUD operations.

  MediatR implements a mediator pattern that helps abstract objects in handling command and query operations within an application. The mediator pattern prevents direct communication between one object and others, reducing dependencies in the system. This allows the code to be more modular, easier to maintain, and testable.

- Throughout the successful completion of the project, effective communication and collaboration among team members played a significant role. Addressing challenges together as a team ensured the project's successful outcome. Additionally, we conducted necessary tests upon project completion, ensuring the accurate and reliable functionality of the application.

## Halime Elif's Part  [![Halime Elif](https://img.shields.io/badge/Elif-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/utopica)

## Issues and Solutions
- Regarding the changes in this project, we resolved conflicts that occurred in the files. Additionally, we encountered some difficulties while attempting to use the MediatR library in the CommandHandler files. Through our researches, we made some modifications to eliminate unnecessary information presented to the user, which significantly contributed to the project. Simultaneously, we consistently encountered errors while trying to add adopters, pets, healthrecords and adoptions to the database. We were able to easily resolve this issues, stemming from a foreign key errors, through internet research and collaboratively support each other as a team.
