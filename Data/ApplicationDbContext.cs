using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KulaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace KulaMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedUsers(builder);
        this.SeedRoles(builder);
        this.SeedUserRoles(builder);
        this.SeedUser(builder);
        this.SeedCoursesWithImages(builder);
        this.SeedModulesForCourses(builder);
    }
    private void SeedUsers(ModelBuilder builder)
    {
        IdentityUser user = new IdentityUser()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            Email = "admin@gmail.com",
            LockoutEnabled = false,
            PhoneNumber = "1234567890"
        };

        PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
        passwordHasher.HashPassword(user, "Admin*123");
        builder.Entity<IdentityUser>().HasData(user);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Instructor", ConcurrencyStamp = "2", NormalizedName = "Instructor" },
            new IdentityRole() { Id = "de7013f0-8790-5417-abh9-e324f91r7442", Name = "Student", ConcurrencyStamp = "3", NormalizedName = "Student" }
            );
    }
    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
        );
    }
    private void SeedUser(ModelBuilder builder)
    {
        var users = new List<User>
    {
        new User
        {
            ID = "1",
            FirstName = "John",
            LastName = "Doe"
        },
        new User
        {
            ID = "2",
            FirstName = "Jane",
            LastName = "Smith"
        },
        new User
        {
            ID = "3",
            FirstName = "Alice",
            LastName = "Johnson"
        }
    };

        builder.Entity<User>().HasData(users);
    }
    private void SeedCoursesWithImages(ModelBuilder builder)
    {
        // Seed three courses with ImageURLs from the web
        var courses = new List<Course>
    {
        new Course
        {
            ID = "1",
            CollectionID = "1",
            Title = "Web Development Fundamentals",
            ShortDescription = "Explore the world of web development.",
            ImageUrl = "https://res.cloudinary.com/db1z5jvko/image/upload/v1699925247/_4a85f8a5-1fa6-4af0-a0aa-80b9a21d0a2a_cgk4at.jpg",
            CreatedAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
            Uploader = "John Doe",
            published = Publish.Now,
            visibility = Visible.Public
        },
        new Course
        {
            ID = "2",
            CollectionID = "2",
            Title = "Introduction to Programming",
            ShortDescription = "Learn the basics of programming.",
            ImageUrl = "https://res.cloudinary.com/db1z5jvko/image/upload/v1699925324/_e007e3ec-a621-4208-a466-da5a7e316ae3_bjrqhr.jpg",
            CreatedAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
            Uploader = "Jane Smith",
            published = Publish.Now,
            visibility = Visible.Public
        },
        new Course
        {
            ID = "3",
            CollectionID = "3",
            Title = "Data Science Essentials",
            ShortDescription = "Dive into the world of data science.",
            ImageUrl = "https://res.cloudinary.com/db1z5jvko/image/upload/v1699925354/_c06263d7-48bf-4db4-80fe-c0efdac6cd80_zuhjok.jpg",
            CreatedAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
            Uploader = "Alice Johnson",
            published = Publish.Now,
            visibility = Visible.Public
        }
    };

        builder.Entity<Course>().HasData(courses);
    }
    private void SeedModulesForCourses(ModelBuilder builder)
    {
        var modules = new List<Module>
    {
        new Module
        {
            ID = "1",
            CollectionID = "1",
            Language = "English",
            Title = "Getting Started with Web Development",
            ShortDescription = "Begin your journey into web development.",
            LongDescription = "In this module, you will embark on a journey into the exciting world of web development. " +
                "You'll learn the fundamentals of HTML, CSS, and JavaScript, the three core technologies " +
                "that power the web. By the end of this module, you'll have the foundational knowledge " +
                "to create your own web pages and start your web development adventure.",
            Video = "web-dev-intro.mp4",
            Uploader = "John Doe",
            Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
        },
        new Module
        {
            ID = "2",
            CollectionID = "1",
            Language = "English",
            Title = "CSS Styling for Web Pages",
            ShortDescription = "Learn how to style your web pages with CSS.",
            LongDescription = "## Master the Art of Web Page Styling\n" +
    "In this comprehensive module, you will dive deep into the world of Cascading Style Sheets (CSS). " +
    "CSS is the key to making your web pages visually appealing, and it plays a crucial role in creating " +
    "stunning and user-friendly designs. Whether you're a web developer or a designer, mastering CSS " +
    "is essential for creating modern, responsive web pages.\n\n" +

    "### Topics Covered\n" +
    "1. **Introduction to CSS**: Begin by understanding the core concepts of CSS, including selectors " +
    "and properties. Learn how to create your style rules and link CSS to your HTML documents.\n" +

    "2. **Box Model**: Delve into the CSS box model, which defines how elements are rendered in web " +
    "browsers. Learn how to control dimensions, margins, and padding for precise layout design.\n" +

    "3. **Layout and Positioning**: Explore different layout techniques, such as float, flexbox, and " +
    "grid. Discover how to control the positioning of elements on your web pages for a responsive design.\n" +

    "4. **Typography and Color**: Dive into text formatting, font styling, and color choices to make " +
    "your content visually appealing and readable.\n" +

    "5. **Transitions and Animations**: Learn how to add animations and transitions to your web " +
    "elements, making your pages interactive and engaging.\n\n" +

    "### Practical Skills\n" +
    "By the end of this module, you'll have practical skills that allow you to:\n" +
    "- Create beautifully styled web pages\n" +
    "- Implement responsive layouts\n" +
    "- Enhance user experience through interactive elements\n\n" +

    "Whether you're a beginner or an experienced developer, this module will elevate your web " +
    "design and development skills to the next level. Join us on this journey to becoming a CSS master!",

            Video = "css-styling.mp4",
            Uploader = "John Doe",
            Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
        },
        new Module
{
    ID = "3",
    CollectionID = "1",
    Language = "English",
    Title = "Mastering Data Science Techniques",
    ShortDescription = "Dive deep into the world of data science.",
    LongDescription = "## Unlock the Power of Data Science\n" +
    "In this in-depth module, you will explore the exciting and transformative world of data science. " +
    "Data science is at the heart of modern decision-making and insights, and it plays a pivotal role " +
    "across industries. Whether you're a budding data scientist or a professional looking to harness " +
    "data-driven insights, this module is your gateway to mastering data science techniques.\n\n" +

    "### Topics Covered\n" +
    "1. **Data Analysis**: Begin with the fundamentals of data analysis. Learn how to collect, clean, " +
    "and explore data to derive meaningful insights.\n" +

    "2. **Statistical Analysis**: Delve into statistical methods to make data-driven decisions. " +
    "Understand concepts like probability, hypothesis testing, and regression analysis.\n" +

    "3. **Machine Learning**: Explore machine learning algorithms for predictive analytics, " +
    "classification, and clustering. Learn how to implement models and evaluate their performance.\n" +

    "4. **Data Visualization**: Master the art of data visualization using tools like Matplotlib " +
    "and Seaborn. Create compelling visuals to communicate data insights effectively.\n" +

    "5. **Big Data and AI**: Discover how to work with big data technologies and harness the power " +
    "of artificial intelligence to solve complex problems.\n\n" +

    "### Practical Skills\n" +
    "By the end of this module, you'll have practical skills that allow you to:\n" +
    "- Analyze and interpret data\n" +
    "- Make data-driven decisions\n" +
    "- Develop machine learning models\n" +
    "- Create meaningful data visualizations\n\n" +

    "Whether you're a data science enthusiast or a professional aiming to advance your career, " +
    "this module will equip you with the knowledge and skills to tackle real-world data challenges " +
    "with confidence. Join us on this journey to master data science techniques!",
    },
    new Module
    {
        ID = "4",
        CollectionID = "2",
        Language = "English",
        Title = "JavaScript Fundamentals",
        LongDescription = "## Mastering JavaScript for Web Development\n" +
        "Welcome to the fascinating world of JavaScript! In this module, we will dive deep into " +
        "JavaScript fundamentals. JavaScript is the backbone of interactivity on the web, and " +
        "understanding it is essential for any web developer.\n\n" +

        "### Topics Covered\n" +
        "1. **JavaScript Basics**: Get started with JavaScript syntax, variables, and data types. " +
        "Learn how to write your first JavaScript code.\n" +

        "2. **Control Structures**: Explore if statements, loops, and switch statements. Understand " +
        "how to control the flow of your code.\n" +

        "3. **Functions and Objects**: Dive into functions, objects, and their role in building " +
        "complex web applications. Learn about the Document Object Model (DOM).\n" +

        "4. **Event Handling**: Understand how to handle user interactions and create responsive " +
        "web pages. Work with event listeners and event-driven programming.\n" +

        "5. **Asynchronous JavaScript**: Explore asynchronous programming, promises, and " +
        "AJAX to create dynamic and responsive web applications.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Write JavaScript code for web applications\n" +
        "- Create dynamic and interactive web pages\n" +
        "- Handle user interactions and events\n" +
        "- Work with the DOM to manipulate web content\n\n" +

        "Whether you're new to JavaScript or want to deepen your knowledge, this module will " +
        "prepare you to create interactive and engaging web applications.",
        Video = "javascript-fundamentals.mp4",
        Uploader = "Jane Smith",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    },
    new Module
    {
        ID = "5",
        CollectionID = "2",
        Language = "English",
        Title = "Responsive Web Design",
        LongDescription = "## Crafting Stunning Responsive Web Pages\n" +
        "Responsive web design is crucial in today's digital landscape. In this module, you will " +
        "master the art of creating web pages that adapt seamlessly to various devices and screen " +
        "sizes. You'll learn the principles, techniques, and best practices for building responsive " +
        "websites.\n\n" +

        "### Topics Covered\n" +
        "1. **Understanding Responsive Design**: Learn the fundamentals of responsive design and " +
        "why it's important in the mobile-first era.\n" +

        "2. **Media Queries**: Dive into CSS media queries to control the layout and styling " +
        "of your web pages based on screen characteristics.\n" +

        "3. **Flexible Layouts**: Explore flexible grid systems and flexbox to create fluid " +
        "and adaptable page layouts.\n" +

        "4. **Responsive Images**: Learn how to handle responsive images and optimize them " +
        "for various devices and resolutions.\n" +

        "5. **Testing and Debugging**: Discover tools and techniques for testing and debugging " +
        "your responsive designs across multiple devices.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Create responsive web designs that work on various devices\n" +
        "- Optimize images for different screen sizes\n" +
        "- Test and troubleshoot responsive layouts\n\n" +

        "Whether you're a web developer or a designer, this module will empower you to create " +
        "web pages that provide an excellent user experience on desktops, tablets, and mobile devices.",
        Video = "responsive-design.mp4",
        Uploader = "Jane Smith",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    },
    new Module
    {
        ID = "6",
        CollectionID = "2",
        Language = "English",
        Title = "Web Accessibility Essentials",
        LongDescription = "## Ensuring Inclusive Web Experiences\n" +
        "Web accessibility is a fundamental aspect of web development. In this module, you will " +
        "learn the essentials of making web content accessible to people with disabilities. " +
        "Creating inclusive web experiences is not only a legal requirement but also a moral " +
        "and ethical obligation.\n\n" +

        "### Topics Covered\n" +
        "1. **Introduction to Web Accessibility**: Understand the importance of web accessibility " +
        "and its impact on various user groups.\n" +

        "2. **WCAG Guidelines**: Explore the Web Content Accessibility Guidelines (WCAG) and " +
        "how they define accessible web content.\n" +
        "3. **Semantic HTML**: Learn to use semantic HTML elements for improved accessibility and " +
        "proper document structure.\n" +

        "4. **Accessible Forms and Multimedia**: Discover best practices for creating accessible " +
        "forms, images, and multimedia content.\n" +

        "5. **Testing and Remediation**: Explore tools and techniques for testing and remediating " +
        "web content to ensure compliance with accessibility standards.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Create web content that is accessible to all users\n" +
        "- Understand and apply WCAG guidelines\n" +
        "- Test and remediate web content for accessibility\n\n" +

        "Whether you're a web developer, designer, or content creator, this module will equip you " +
        "with the knowledge and skills to make the web a more inclusive place for everyone.",
        Video = "web-accessibility.mp4",
        Uploader = "Jane Smith",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    },
     new Module
    {
        ID = "7",
        CollectionID = "3",
        Language = "English",
        Title = "Data Wrangling and Preprocessing",
        LongDescription = "## Mastering Data Wrangling for Data Science\n" +
        "Data wrangling is an essential step in the data science process. In this module, you'll " +
        "learn how to acquire, clean, and preprocess data to make it suitable for analysis. " +
        "Data quality and preparation are critical to deriving meaningful insights and " +
        "building accurate models.\n\n" +

        "### Topics Covered\n" +
        "1. **Data Acquisition**: Explore various data sources and methods for collecting data. " +
        "Understand data formats and APIs for data retrieval.\n" +

        "2. **Data Cleaning**: Learn how to identify and handle missing data, outliers, and " +
        "inconsistencies in your datasets. Apply techniques for data cleansing.\n" +

        "3. **Data Transformation**: Discover methods for reshaping, aggregating, and transforming " +
        "data to prepare it for analysis. Work with tools like Pandas and Numpy.\n" +

        "4. **Data Integration**: Integrate data from multiple sources and combine datasets to " +
        "create a unified dataset for analysis.\n" +

        "5. **Data Quality and Validation**: Ensure data quality and validate your datasets for " +
        "accuracy and completeness.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Acquire and clean data from various sources\n" +
        "- Transform and reshape data for analysis\n" +
        "- Integrate and validate datasets\n\n" +

        "Whether you're a data scientist or aspiring to become one, this module will equip you with " +
        "the skills needed to prepare data for meaningful analysis.",
        Video = "data-wrangling.mp4",
        Uploader = "Alice Johnson",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    },
    new Module
    {
        ID = "8",
        CollectionID = "3",
        Language = "English",
        Title = "Statistical Analysis and Hypothesis Testing",
        LongDescription = "## Uncover Insights with Statistical Analysis\n" +
        "Statistical analysis is a fundamental tool in the data scientist's toolkit. In this module, " +
        "you'll dive into statistical concepts and techniques to uncover patterns, trends, and insights " +
        "within your data. Whether you're new to statistics or looking to deepen your knowledge, this " +
        "module will provide you with the skills to make data-driven decisions.\n\n" +

        "### Topics Covered\n" +
        "1. **Descriptive Statistics**: Learn how to describe and summarize data using measures " +
        "of central tendency and dispersion. Create meaningful visualizations of data.\n" +

        "2. **Inferential Statistics**: Understand the principles of inferential statistics, " +
        "hypothesis testing, and confidence intervals.\n" +

        "3. **Correlation and Regression**: Explore the relationships between variables and " +
        "learn how to perform regression analysis.\n" +

        "4. **Statistical Tests**: Learn about different types of statistical tests, including " +
        "t-tests, ANOVA, and chi-square tests.\n" +

        "5. **Practical Applications**: Apply statistical analysis to real-world data " +
        "and make data-driven decisions.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Analyze data using descriptive and inferential statistics\n" +
        "- Conduct hypothesis tests and make inferences\n" +
        "- Apply statistical analysis to solve real-world problems\n\n" +

        "This module is designed to empower you with the statistical knowledge and skills needed to " +
        "make informed decisions based on data analysis.",
        Video = "statistical-analysis.mp4",
        Uploader = "Alice Johnson",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    },
    new Module
    {
        ID = "9",
        CollectionID = "3",
        Language = "English",
        Title = "Machine Learning Fundamentals",
        LongDescription = "## Journey into the World of Machine Learning\n" +
        "Machine learning is transforming industries and enabling data-driven solutions. " +
        "In this module, you'll embark on a journey into the fundamentals of machine learning. " +
        "You'll learn the core concepts, algorithms, and practical applications that make machine " +
        "learning a powerful tool for data scientists and developers.\n\n" +

        "### Topics Covered\n" +
        "1. **Introduction to Machine Learning**: Understand the basics of machine learning, " +
        "its applications, and the machine learning pipeline.\n" +

        "2. **Supervised Learning**: Explore supervised learning algorithms, including " +
        "regression and classification. Learn about decision trees, support vector machines, " +
        "and more.\n" +

        "3. **Unsupervised Learning**: Dive into unsupervised learning, clustering, and dimensionality " +
        "reduction techniques.\n" +

        "4. **Model Evaluation**: Discover how to evaluate and validate machine learning models " +
        "using metrics and cross-validation.\n" +

        "5. **Practical Applications**: Apply machine learning to real-world datasets and " +
        "solve predictive and classification problems.\n\n" +

        "### Practical Skills\n" +
        "By the end of this module, you'll have practical skills that allow you to:\n" +
        "- Understand the principles of machine learning\n" +
        "- Build and evaluate machine learning models\n" +
        "- Apply machine learning to real-world problems\n\n" +

        "Whether you're a data scientist, developer, or aspiring to work in machine learning, " +
        "this module will provide you with the foundation to explore the exciting world of " +
        "machine learning.",
        Video = "machine-learning-fundamentals.mp4",
        Uploader = "Alice Johnson",
        Iat = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
    }
    };

        builder.Entity<Module>().HasData(modules);
    }

    public DbSet<KulaMVC.Models.Course> Course { get; set; }
    public DbSet<KulaMVC.Models.Module> Module { get; set; }
    public DbSet<KulaMVC.Models.User> User { get; set; }

}
