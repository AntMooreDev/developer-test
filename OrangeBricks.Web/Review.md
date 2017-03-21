I have completed the tasks as requested. In a real production environment there are many optimisations and 
further functionality that I would include. I had a lot of fun working on this task and learning new skills
required to meet the challenges.

In regards to the existing code there are several improvement I would make;

1. I would remove any unnecessary references from the `.cs` files. Whilst this doesn't have any affect on 
the performance at run-time, it can slow down the IDE and it's good practice to maintain clean and concise
code.

2. I would add logging to the system which will help identify and debug any issues that may be experienced by 
users and will allow analysts the track any security issues. For this I would make use of Log4Net.

3. There are several security improvements that can be made to the login and authentication methods. Making use
of external login features, we can improve usability and reinforce the security of user accounts. Secondly 
two-factor authentication can be used to add an extra layer of security to the login functionality.

4. SSL should be used to ensure secure connections and to comply with the new direction Google and other search
engines are taking to ranking websites.

5. Another security concern is the use of integers for ID fields. I would make use of GUIDs for all identity 
fields to prevent users from guessing/brute forcing attacks on the system.

---

In addition to the above improvements to the existing code base, I would also make the following to my own
changes if this were a real production environment:

1. I would implement a full event system that can trigger the notification system asynchronously. 

2. I would send email notifications to users when certain events are triggered.

3. I would complete my Bardic JavaScript plugin _(this is currently in alpha)_ to a production ready level.

4. I would improve my implementation of React, utilising a full flux approach to the dynamic functionality.

5. I would improve the notification system;
	* I would inform users of the specifics of the notification.
	* To be more scalable I would add some server-side throttling to reduce the number of AJAX requests if the
	user becomes inactive.
	* I would remove the notification badges and mark the statys as 'read' when the notifications are read.

---

This is the first time I have had to complete a coding challenge for an application and I have really enjoyed
completing the tasks. I've had to learn some new skills in order to fulfill the tasks and that's been incredibly
fun. I had no exposure to React or Unit Tests before taking on this challenge and that may show in the code that
I have written. That being said, I feel that the code I have written is very robust and shows how easily I can
adapt to new technologies and methodologies.

The structure of the project is well put together and it is refreshing to see a well put together MVC project.