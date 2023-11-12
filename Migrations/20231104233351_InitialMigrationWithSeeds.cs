using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KulaLearnMVC.Migrations
{
    public partial class InitialMigrationWithSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    CollectionID = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<int>(type: "INTEGER", nullable: false),
                    Uploader = table.Column<string>(type: "TEXT", nullable: true),
                    published = table.Column<int>(type: "INTEGER", nullable: false),
                    visibility = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    CollectionID = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    LongDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Video = table.Column<string>(type: "TEXT", nullable: true),
                    Uploader = table.Column<string>(type: "TEXT", nullable: true),
                    Iat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "Instructor", "Instructor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de7013f0-8790-5417-abh9-e324f91r7442", "3", "Student", "Student" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "4550e1d7-81e5-47a2-9426-a25057a92ec0", "admin@gmail.com", false, false, null, null, null, null, "1234567890", false, "fde5af89-e221-4f6c-86a0-8f465bb8b646", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "ID", "CollectionID", "CreatedAt", "ImageUrl", "ShortDescription", "Title", "Uploader", "published", "visibility" },
                values: new object[] { "1", "1", 1699140830, "https://example.com/course1.jpg", "Explore the world of web development.", "Web Development Fundamentals", "John Doe", 0, 1 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "ID", "CollectionID", "CreatedAt", "ImageUrl", "ShortDescription", "Title", "Uploader", "published", "visibility" },
                values: new object[] { "2", "2", 1699140830, "https://example.com/course2.jpg", "Learn the basics of programming.", "Introduction to Programming", "Jane Smith", 0, 1 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "ID", "CollectionID", "CreatedAt", "ImageUrl", "ShortDescription", "Title", "Uploader", "published", "visibility" },
                values: new object[] { "3", "3", 1699140830, "https://example.com/course3.jpg", "Dive into the world of data science.", "Data Science Essentials", "Alice Johnson", 0, 1 });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "1", "1", 1699140830, "English", "In this module, you will embark on a journey into the exciting world of web development. You'll learn the fundamentals of HTML, CSS, and JavaScript, the three core technologies that power the web. By the end of this module, you'll have the foundational knowledge to create your own web pages and start your web development adventure.", "Begin your journey into web development.", "Getting Started with Web Development", "John Doe", "web-dev-intro.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "2", "1", 1699140830, "English", "## Master the Art of Web Page Styling\nIn this comprehensive module, you will dive deep into the world of Cascading Style Sheets (CSS). CSS is the key to making your web pages visually appealing, and it plays a crucial role in creating stunning and user-friendly designs. Whether you're a web developer or a designer, mastering CSS is essential for creating modern, responsive web pages.\n\n### Topics Covered\n1. **Introduction to CSS**: Begin by understanding the core concepts of CSS, including selectors and properties. Learn how to create your style rules and link CSS to your HTML documents.\n2. **Box Model**: Delve into the CSS box model, which defines how elements are rendered in web browsers. Learn how to control dimensions, margins, and padding for precise layout design.\n3. **Layout and Positioning**: Explore different layout techniques, such as float, flexbox, and grid. Discover how to control the positioning of elements on your web pages for a responsive design.\n4. **Typography and Color**: Dive into text formatting, font styling, and color choices to make your content visually appealing and readable.\n5. **Transitions and Animations**: Learn how to add animations and transitions to your web elements, making your pages interactive and engaging.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Create beautifully styled web pages\n- Implement responsive layouts\n- Enhance user experience through interactive elements\n\nWhether you're a beginner or an experienced developer, this module will elevate your web design and development skills to the next level. Join us on this journey to becoming a CSS master!", "Learn how to style your web pages with CSS.", "CSS Styling for Web Pages", "John Doe", "css-styling.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "3", "1", 0, "English", "## Unlock the Power of Data Science\nIn this in-depth module, you will explore the exciting and transformative world of data science. Data science is at the heart of modern decision-making and insights, and it plays a pivotal role across industries. Whether you're a budding data scientist or a professional looking to harness data-driven insights, this module is your gateway to mastering data science techniques.\n\n### Topics Covered\n1. **Data Analysis**: Begin with the fundamentals of data analysis. Learn how to collect, clean, and explore data to derive meaningful insights.\n2. **Statistical Analysis**: Delve into statistical methods to make data-driven decisions. Understand concepts like probability, hypothesis testing, and regression analysis.\n3. **Machine Learning**: Explore machine learning algorithms for predictive analytics, classification, and clustering. Learn how to implement models and evaluate their performance.\n4. **Data Visualization**: Master the art of data visualization using tools like Matplotlib and Seaborn. Create compelling visuals to communicate data insights effectively.\n5. **Big Data and AI**: Discover how to work with big data technologies and harness the power of artificial intelligence to solve complex problems.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Analyze and interpret data\n- Make data-driven decisions\n- Develop machine learning models\n- Create meaningful data visualizations\n\nWhether you're a data science enthusiast or a professional aiming to advance your career, this module will equip you with the knowledge and skills to tackle real-world data challenges with confidence. Join us on this journey to master data science techniques!", "Dive deep into the world of data science.", "Mastering Data Science Techniques", null, null });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "4", "2", 1699140830, "English", "## Mastering JavaScript for Web Development\nWelcome to the fascinating world of JavaScript! In this module, we will dive deep into JavaScript fundamentals. JavaScript is the backbone of interactivity on the web, and understanding it is essential for any web developer.\n\n### Topics Covered\n1. **JavaScript Basics**: Get started with JavaScript syntax, variables, and data types. Learn how to write your first JavaScript code.\n2. **Control Structures**: Explore if statements, loops, and switch statements. Understand how to control the flow of your code.\n3. **Functions and Objects**: Dive into functions, objects, and their role in building complex web applications. Learn about the Document Object Model (DOM).\n4. **Event Handling**: Understand how to handle user interactions and create responsive web pages. Work with event listeners and event-driven programming.\n5. **Asynchronous JavaScript**: Explore asynchronous programming, promises, and AJAX to create dynamic and responsive web applications.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Write JavaScript code for web applications\n- Create dynamic and interactive web pages\n- Handle user interactions and events\n- Work with the DOM to manipulate web content\n\nWhether you're new to JavaScript or want to deepen your knowledge, this module will prepare you to create interactive and engaging web applications.", null, "JavaScript Fundamentals", "Jane Smith", "javascript-fundamentals.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "5", "2", 1699140830, "English", "## Crafting Stunning Responsive Web Pages\nResponsive web design is crucial in today's digital landscape. In this module, you will master the art of creating web pages that adapt seamlessly to various devices and screen sizes. You'll learn the principles, techniques, and best practices for building responsive websites.\n\n### Topics Covered\n1. **Understanding Responsive Design**: Learn the fundamentals of responsive design and why it's important in the mobile-first era.\n2. **Media Queries**: Dive into CSS media queries to control the layout and styling of your web pages based on screen characteristics.\n3. **Flexible Layouts**: Explore flexible grid systems and flexbox to create fluid and adaptable page layouts.\n4. **Responsive Images**: Learn how to handle responsive images and optimize them for various devices and resolutions.\n5. **Testing and Debugging**: Discover tools and techniques for testing and debugging your responsive designs across multiple devices.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Create responsive web designs that work on various devices\n- Optimize images for different screen sizes\n- Test and troubleshoot responsive layouts\n\nWhether you're a web developer or a designer, this module will empower you to create web pages that provide an excellent user experience on desktops, tablets, and mobile devices.", null, "Responsive Web Design", "Jane Smith", "responsive-design.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "6", "2", 1699140830, "English", "## Ensuring Inclusive Web Experiences\nWeb accessibility is a fundamental aspect of web development. In this module, you will learn the essentials of making web content accessible to people with disabilities. Creating inclusive web experiences is not only a legal requirement but also a moral and ethical obligation.\n\n### Topics Covered\n1. **Introduction to Web Accessibility**: Understand the importance of web accessibility and its impact on various user groups.\n2. **WCAG Guidelines**: Explore the Web Content Accessibility Guidelines (WCAG) and how they define accessible web content.\n3. **Semantic HTML**: Learn to use semantic HTML elements for improved accessibility and proper document structure.\n4. **Accessible Forms and Multimedia**: Discover best practices for creating accessible forms, images, and multimedia content.\n5. **Testing and Remediation**: Explore tools and techniques for testing and remediating web content to ensure compliance with accessibility standards.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Create web content that is accessible to all users\n- Understand and apply WCAG guidelines\n- Test and remediate web content for accessibility\n\nWhether you're a web developer, designer, or content creator, this module will equip you with the knowledge and skills to make the web a more inclusive place for everyone.", null, "Web Accessibility Essentials", "Jane Smith", "web-accessibility.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "7", "3", 1699140830, "English", "## Mastering Data Wrangling for Data Science\nData wrangling is an essential step in the data science process. In this module, you'll learn how to acquire, clean, and preprocess data to make it suitable for analysis. Data quality and preparation are critical to deriving meaningful insights and building accurate models.\n\n### Topics Covered\n1. **Data Acquisition**: Explore various data sources and methods for collecting data. Understand data formats and APIs for data retrieval.\n2. **Data Cleaning**: Learn how to identify and handle missing data, outliers, and inconsistencies in your datasets. Apply techniques for data cleansing.\n3. **Data Transformation**: Discover methods for reshaping, aggregating, and transforming data to prepare it for analysis. Work with tools like Pandas and Numpy.\n4. **Data Integration**: Integrate data from multiple sources and combine datasets to create a unified dataset for analysis.\n5. **Data Quality and Validation**: Ensure data quality and validate your datasets for accuracy and completeness.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Acquire and clean data from various sources\n- Transform and reshape data for analysis\n- Integrate and validate datasets\n\nWhether you're a data scientist or aspiring to become one, this module will equip you with the skills needed to prepare data for meaningful analysis.", null, "Data Wrangling and Preprocessing", "Alice Johnson", "data-wrangling.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "8", "3", 1699140830, "English", "## Uncover Insights with Statistical Analysis\nStatistical analysis is a fundamental tool in the data scientist's toolkit. In this module, you'll dive into statistical concepts and techniques to uncover patterns, trends, and insights within your data. Whether you're new to statistics or looking to deepen your knowledge, this module will provide you with the skills to make data-driven decisions.\n\n### Topics Covered\n1. **Descriptive Statistics**: Learn how to describe and summarize data using measures of central tendency and dispersion. Create meaningful visualizations of data.\n2. **Inferential Statistics**: Understand the principles of inferential statistics, hypothesis testing, and confidence intervals.\n3. **Correlation and Regression**: Explore the relationships between variables and learn how to perform regression analysis.\n4. **Statistical Tests**: Learn about different types of statistical tests, including t-tests, ANOVA, and chi-square tests.\n5. **Practical Applications**: Apply statistical analysis to real-world data and make data-driven decisions.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Analyze data using descriptive and inferential statistics\n- Conduct hypothesis tests and make inferences\n- Apply statistical analysis to solve real-world problems\n\nThis module is designed to empower you with the statistical knowledge and skills needed to make informed decisions based on data analysis.", null, "Statistical Analysis and Hypothesis Testing", "Alice Johnson", "statistical-analysis.mp4" });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ID", "CollectionID", "Iat", "Language", "LongDescription", "ShortDescription", "Title", "Uploader", "Video" },
                values: new object[] { "9", "3", 1699140830, "English", "## Journey into the World of Machine Learning\nMachine learning is transforming industries and enabling data-driven solutions. In this module, you'll embark on a journey into the fundamentals of machine learning. You'll learn the core concepts, algorithms, and practical applications that make machine learning a powerful tool for data scientists and developers.\n\n### Topics Covered\n1. **Introduction to Machine Learning**: Understand the basics of machine learning, its applications, and the machine learning pipeline.\n2. **Supervised Learning**: Explore supervised learning algorithms, including regression and classification. Learn about decision trees, support vector machines, and more.\n3. **Unsupervised Learning**: Dive into unsupervised learning, clustering, and dimensionality reduction techniques.\n4. **Model Evaluation**: Discover how to evaluate and validate machine learning models using metrics and cross-validation.\n5. **Practical Applications**: Apply machine learning to real-world datasets and solve predictive and classification problems.\n\n### Practical Skills\nBy the end of this module, you'll have practical skills that allow you to:\n- Understand the principles of machine learning\n- Build and evaluate machine learning models\n- Apply machine learning to real-world problems\n\nWhether you're a data scientist, developer, or aspiring to work in machine learning, this module will provide you with the foundation to explore the exciting world of machine learning.", null, "Machine Learning Fundamentals", "Alice Johnson", "machine-learning-fundamentals.mp4" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { "1", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { "2", "Jane", "Smith" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { "3", "Alice", "Johnson" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
