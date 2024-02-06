# Junior Developer FAQ - frequently asked questions

### It says that frameworks are restricted such as Lumen, Laravel, Symfony etc. Does the same go for the front-end as well? Or can I just use angular to save time?

Main requirement of senior task is Frameworks are restricted for whole project.

### What is meant by " Independent environment"?

Docker.

### Does the “no frameworks” restriction apply to PHP only or to the whole project?

BE (backend) frameworks are not allowed, however FE frameworks as vue.js and react can be used

### Is basic PHP enough to do junior developer's test?(HTML and CSS is obviously required)

We require at least basic object-oriented (OOP) php knowledge, as well would be great to see some javascript, but experience with any programming language and tool is advantage.

### Since there is an emphasis on PHP coding standards in the test is there an issue with using a package such as PHP coding standards fixer?

Yes, go ahead

### Can I share source code on GitHub, because I have account on GitHub and not have on BitBucket?

We don’t see a problem here but yes, you can host your repo on GitHub

### Do you want styling too or is the bare minimum enough? I could go on.

It would be good to see stylings, but that’s up to you. There is schematic layout example in PDF file we sent to you. Please follow this layout, all other is an advantage.

### Can I use a template engine?

Yes, go ahead

### Am I allowed to use frontend frameworks like React?

Yes, it is allowed

### Does the “no frameworks” restriction apply to PHP only or to the whole project?

This means that frameworks restricted for the whole project. Candidate can write themself custom framework if he/she wants

### The requirements optionally mention a PSR1 or 2 coding standard, would it still be ok if I use PSR-12 as this seems like it might be slightly more flexible?

Its optional. He can use any PSR As of 2019-08-10 PSR-2 has been marked as deprecated. PSR-12 is now recommended as an alternative.

### About ‘’Product Add’’. This page should be a separately or after clicked cards should be opened? And SKU, Name and Price. What information am I writing here? I need a little bit information and explanation with ‘’Product Add’’.

Product Add should be as separate page, there are form inputs and submit button.

### Is it mandatory to have a database with a list of goods connected?

Yes

### Does this also apply to the CSS styling?

Candidate can use some custom CSS and adapt it I guess, more important is PHP, MySQL, JS (jQuery) for this copying is not allowed.

### What kind of slider I am supposed to make. Is it one, that could control a quantity ( like a volume slider) or more like a carousel(displays a different kind of content when a button is pressed)? Is there an example that you could maybe provide?

You need to create carousel slider, that switches between content, like this - https://kenwheeler.github.io/slick/

### I have a question about the first page. Is this element with an arrow (I've marked it with red in the attached file) a dropdown list, where all checked products should appear in?

it’s a dropdown with all possible mass actions, in your case, there should be only 1 option “Mass delete”

### Do I need to create local HTML, in which with Javascript and CSS help in section ''product add'', I add products, it shows in section ''product list''?

You have to use PHP to handle product adding and html/js/css to create frontend for your app. This is mentioned in requirement list and it also contains list of tools you have to use for this task.

### Should the look of the page be the same as per the given design in the test?

This is just a mock-up. You can create own design/layout, but overall structure should be the same - product adding form and product list.

### What attributes should be included in the SKU? It can be generated using the only name and product type, or I need to include special attributes like size also? (DVD001, where 001 is ‘’product name’' id) or (DVD00102, where 02 is special attribute ‘’size’' id)

Initially SKU field is intended to be a regular input field, but yes, you can make it auto-generated depending on other product’s data. In this case it’s up to you to choose the pattern, but remember, SKU should be unique.

#### Is it possible to use the SKU auto-generator instead of the SKU input field?

No, because this is requirement from the test and it's more practice scenario because SKU basically defines by business user/agent

### In the points where you need to take into the fact that you can easily add new categories and attributes meaning in the code or should there be buttons on the site itself? And if in the code, then this needs to be done with the help of a factory method?

t's should be code logic. Just imagine that in the future you will have 1000 different attributes. How better do you code for easily extending code in the future?

#### Could you explain in more detail the requirement: Avoid using conditional statements for handling differences in product types.

This requirement means avoid conditional statements (if-else, switch and etc.). You need to show your OOP knowledge and understanding to realize this requirement. In this case something like if($productType === 'DVD') - invalid.

### Is it allowed to use a local server with PHPMyAdmin, or I should manually setup the database with MySQL?

It is up to you

### Avoid using conditional statements for handling differences in product types. Should I not use conditionals to check what product type has been selected by the user?

You should avoid try-catch and if-else that checks product types

### There must be two pages, one page add product to database, but another page should display this product from database?

Yes

### I have to use MySQL database or I can write in a .json file and then get data from it?

MySQL:^5.6 - obligatory - one of the main requirements, answer - you must use MySQL.

### Can i use features from PHP 7.1, 7.2, 7.3 7.4? And MySQL 5.7 version features?

Yes and yes

### What is the correct way to store functions PHP functions? Is it okay that there are functions that are not associated with a direct OOP class? If yes, then what is the correct way to store them (folder and function count in one PHP file)?

You should show your OOP approach knowledge (Classes inherits, polymorphism, abstract classes usage and etc.), we really suggest you avoid a procedural code because the main requirement of the Junior Developer test is the OOP approach.

### For now, I have set up my page to suit the 1080p screen and for smaller screens objects are big and side-scrolling is needed (nothing is overlapping and is fine). Should I make the page dynamically change on window size?

It's not required but if you want and can do it - you can do it

### Should the "Product Add" page have a return to "Product List" page without adding a new product?

This is also not required
