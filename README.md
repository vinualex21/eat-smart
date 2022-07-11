# Eat Smart
Daily meal planner that returns 3 meals for a daily calorie limit.

<details><summary>USER PROFILE</summary>
  
- ### Create User
  
  Create a new user profile.

 **POST** ``http://localhost:5057/api/User``
 
#### Parameters
  
| Name  | Type | Example  | Description |
| ------------- | ------------- | ------------- | ------------- |
| userId  | number  | 463  | The user id. User can set a prefered id, if its not already taken. If left 0, system will auto-generate id.  |
| firstName  | string  | John  | The user's first name.  |
| surname  | string  | Doe  | The user's surname.  |
| maxDailyCalories  | number  | 2600  | The maximum total calories that the meals can contain.  |
| intolerances  | string  | Gluten  | A comma-separated list of intolerances. All recipes returned must not contain these ingredients.  |
  
  
- ### View User
  
  View specific user details.

 **GET** ``http://localhost:5057/api/User/{id}``
 
#### Parameters
  
| Name  | Type | Example  | Description |
| ------------- | ------------- | ------------- | ------------- |
| id  | number  | 46  | The user id  |
  
- ### Edit User
  
  Edit existing user details.

 **PUT** ``http://localhost:5057/api/User/{id}``
 
#### Parameters
  
| Name  | Type | Example  | Description |
| ------------- | ------------- | ------------- | ------------- |
| id  | number  | 1022  | The user id  |
| firstName  | string  | John  | The user's first name.  |
| surname  | string  | Doe  | The user's surname.  |
| maxDailyCalories  | number  | 2600  | The maximum total calories that the meals can contain.  |
| intolerances  | string  | Gluten  | A comma-separated list of intolerances. All recipes returned must not contain these ingredients.  |
 
- ### Delete User
  
  Delete user profile permanently.

 **DELETE** ``http://localhost:5057/api/User/{id}``
 
#### Parameters
  
| Name  | Type | Example  | Description |
| ------------- | ------------- | ------------- | ------------- |
| id  | number  | 81  | The user id  |

</details>

<details><summary>MEAL PLANNING</summary>
  
- ### Daily Meals for User
  
  Retrieve three meals for a given registered user based on preset maximum daily calories.

 **GET** ``http://localhost:5057/api/Meal/{id}``
 
#### Parameters
  
| Name  | Type | Example  | Description |
| ------------- | ------------- | ------------- | ------------- |
| id  | number  | 583  | The user id  |

  
</details>
