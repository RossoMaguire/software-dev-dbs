## Basic website design made from scratch HTML, CSS and JavaScript. 

The goal is to demonstrate semantic HTML, organised CSS and handling form events with JavaScript.

Working model can be found at: https://condescending-swartz-55270e.netlify.app/index.html



![ScreenShot](https://raw.github.com/RossoMaguire/software-dev-dbs/master/web-dev/assets/images/screen-home.jpg)


![ScreenShot](https://raw.github.com/RossoMaguire/software-dev-dbsmaster/web-dev/assets/images/screen-about.jpg)


![ScreenShot](https://raw.github.com/RossoMaguire/software-dev-dbs/master/web-dev/assets/images/screen-contact.png)



### Business Case

This website is an online solution for Bay View Bed & Breakfast who's goal is to increase an online presence which will attract new guests and provide up-to-date information for returning guests.

### Accessibility Considerations

To make this website accessible I have made the HTML as semantic as possible.

For example, Semantic tags contained in the site include:

- &lt;form>
- &lt;header>
- &lt;nav>
- &lt;main>
- &lt;button>
- &lt;h1>
- &lt;h2>
- alt="" tags on all images
- &lt;html lang="en">
- &lt;href="tel:"> and &lt;href="mailto:"> which are the protocols for telephone and email links

By using Semantic tags like this, screen readers can pick up elements and the buttons throughout the pages can be tabbed between in the correct order - the form can be submitted with return.

I also wanted to maintain SEO in the content of the site by mentioning 'Galway Bay' and 'Galway' where possible in the name of the business and the paragraphs that describe the services.

### Logbook - Painpoints

**Hero:**
- Used a background image on the hero div as I plan on putting text in here and want the image to cover the height and width of the parent div for this content on all pages.

**Services Boxes**
- Cards based layout - a design trend that seems to be in at the moment is rows and cards - prevalent in frameworks such as Bootstrap etc also.

- Using 'display:table' on my '.inner-wrapper' class helped to align my divs and keep them structured in a more robust way.

- I created 4 divs inside the '#services' container div and set the 'width:25%' so that they would make up the full width in a row.

**Partner Section:**
- Using 'display:flex' I was able to space 5 divs evenly containing images of the B&Bs partners which is something not uncommon of home pages for small business's on websites which I have researched.

**Page Templates**
- I copied over my home page and removed the main content so that I just had my header and footer with a blank area to work with in the middle - did this for templating all other pages.

**Contact Page:**
- Created a class 'contact-description' which picked up the same margin as the 'about-description' for consistency. Added a specific 'display:flex' property which would allow me to create a 2 column layout.

- By using 'display-flex' on the wrapper I was able to make my forms width 60% and add another column on the right for contact information without having to specify a width which would align itself to it.

- I was able to generate an iframe of a map on a website called <a href="https://www.maps.ie/create-google-map/">maps.ie</a> which could emulate the website having a Google Map to easily find the location.

- My form uses the attribute in HTML5 'required' however, this is not a robust way of incorporating validation so I still wrote some checks in the JS file that will handle the validation on form submit - the comments there explain my method.

**Services Page - Anchor IDs:**
- I created a 'separator' div between each of these and used an image. This was stylistic choice but also so that I could add anchor ids that could link to the specific part of the page from the Home page cards. For example having the id 'facilities' on the separator I can use 'assets/services/index.html#facilities' on my facilities card button href on the homepage which would jump directly to the separator above the facilities 'services-item' div placing the user at that piece of content on page load.

**Footer:**
- Created a background image that blended in to the body background which is something I have seen on other websites.
- Used pseudo element ':before' so that I could add 'opacity: 0.8' as the colour of the image was quite sharp and this cant be done on a regular div, the background image had to be white at the top so that it could blend in to the body.

- Then underneath that I created the footer and made the background color the same colour as the bottom of the image after the opcaity was applied.

**Responsivness:**
- Following the class we had on responsivness I decided to create a mobile menu which would only show once a hamburger icon is clicked.

- Created a media query which would catch all styles for Tablet and Mobile by using the rule 'max-device-width: 768px' meaning apply these styles to any device under 768px wide. NB PLEASE USE CHROME DEVICE EMULATOR TO TEST INSTEA OF SHIRNKING WINDOW.

- I leveraged JQuery toggle function to check when the hamburger was clicked.

- Made mobile menu vertical by targeting the '#mobile-menu li.nav-link-button' and changing the display to 'block' rather than 'inline' as is on desktop. I floated it to the right of the screen and gave it a z-index higher than that of the header so that it didnt get covered.

- On the homepage I decided to add 'display:none' to the promo section outer div and the partners section. Instead of styling these and increasing the page load / scroll amount for mobile I thought its better to focus attention to driving the user towards only the most important parts of the page on mobile which would be the 4 service boxes and CTA's within.

- After further testing on my older mac laptop I realised that the '.inner wrapper' inside '.main-content' was putting the cards out of place on the homepage so instead of a percentage width I gave it a fixed width on desktop of 1220px

**Other:**
- Added fonts by including Google Fonts CDN in the head as covered in class.

- Made Nav sticky and shrink on page scroll (See JS Comments)

- I added some nifty CSS hover effects to the cards and buttons to give the site a bit more of a feel.

- I used 'transition: 0.3s' which would transition the hover effect at 3 milliseconds rather than a sharp jump which is the default.
- Used section tag to break up sections in the HTML for easier debugging and semantics.

- I sourced images from Google but am aware that for a real world project these should be owned and / or copyrighted.


### Learnings:

Using Firefox & Chrome Dev Tools helps to play around with HTML and CSS on the fly in the browser before making changes in my file.

Content writing and SEO / Accessibility can almost be considered a separate job from designing a website as there are a lot of considerations around accessibility / semantics and SEO is fundamental to the purpose of a site before coding.

If I was to do this project again it makes most sense to adopt a framework like Bootstrap or Foundation and to reverse-engineer these rather than coding from scratch. There is a lot of work 'reinventing the wheel' when trying to adopt Web Design Trends and Styles especially for various devices and it would help a lot to install or borrow from a Framework which handles this.
