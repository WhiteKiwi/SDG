<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SDG_Site.Default" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <title>Out of Well</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="/assets/css/main.css">
</head>

<body>
    <section id="header">
        <div class="container">
            <section id=header>
                <div class="container">
                    <nav>
                        <ul id=mainNavigation class="main-nav">
                            <li>
                                <a href="/" class="logo">Out of Well</a>
                            </li>
                            <div id="responsive-nav" class="responsive-nav">
                                <li>
                                    <a href="/Solutions.aspx" id="begone1" class="other-nav">Solutions</a>
                                </li>
                                <li>
                                    <a href="/LeaderBoard.aspx" id="begone2" class="other-nav">Leaderboard</a>
                                </li>
                            </div>
                            <li>
                                <a href="javascript:void(0);" onclick="showNav()">
                                    <div class="nav-toggle"></div>
                                    <div class="nav-toggle"></div>
                                    <div class="nav-toggle"></div>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div>
                <div class="header-text content-container">
                    <h1>Paving the way to a better future</h1>
                    <img src="/assets/img/app.png" alt="">
                </div>
            </section>
        </div>
    </section>
    <section id="about">
        <h1>About the App</h1>
        <p>Out of Well is an application designed to further the achievement of the United Nations (UN) Sustainable Development
            Goals (SDG's) through education. You will play a fictional character named Jack or Janice that has dreamed of
            traveling the world since childhood and will finally be able to fulfill your dream. You will start your journey
            in Africa and end in Asia. Before your journey is complete, you will have traveled across five continents. Your
            travels will expose you to various problems found around the world and help you understand the underlying issues
            behind said problems. At certain points during the game, you will be asked to come up with a solution to the
            problem.
        </p>
    </section>
    <section id="SDG">
        <div class="container">
            <h1>The United Nations Sustainable Development Goals</h1>
            <div class="container">
                <div class="SDG-grid">
                    <img src="/assets/img/1.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/2.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/3.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/4.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/5.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/6.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/7.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/8.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/9.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/10.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/11.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/12.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/13.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/14.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/15.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/16.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/17.jpg" alt="" width="124px" height="124px">
                    <img src="/assets/img/18.jpg" alt="" width="124px" height="124px">
                </div>
            </div>
        </div>
    </section>
    <br>
    <section id=features>
        <div class="content-container">
            <h1>Features</h1>
            <div class="cards">
                <img src="/assets/img/game-controller.svg" alt="" width="124px" height="124px">
                <div class="feature-card">
                    <p>
                        Out of Well creates an educational yet engaging environment for raising awareness about gloabal issues and the seventeen
                        Sustainable Development Goals. Games are synonymous with the word fun and people learn best whilst
                        having fun. Incentives such as character customization and ranking will provide incentives for users
                        to continue learning. As a result of this approach, users will learn more about the Sustainable Development
                        Goals.
                    </p>
                </div>
                <img src="/assets/img/critical-thinking.svg" alt="" width="124px" height="124px">
                <div class="feature-card">
                    <p>Critical thinking is one of the most important skills users of the app are presented with complex problems
                        and required to formulate a viable and effective solution. These solutions will then be uploaded
                        onto the site and can be freely viewed by others. Coming up with solutions will require that the
                        user to use and improve upon their critical thinking skills. Out of Well goes beyond increasing the
                        rate at which the world develops into a better place and also helps develops one's self.</p>
                </div>
                <img src="/assets/img/education.svg" alt="" width="124px" height="124px">
                <div class="feature-card">
                    <p> Out of Well can be easily integrated into traditional school curriculum. The app can act as a primer
                        to certain topics covered in schools which can include but are not limited to: environmental conservation,
                        health, and the economy. Children will be receptive of Out of Well because of the game element of
                        the app.</p>
                </div>
            </div>
        </div>
    </section>
    <section id="CTA">
        <div class="CTA">

            <img src="/assets/img/logo.png" width="220px" height="220px" class="app-icon">
            <img src="/assets/img/downloadbutton.png " width="50%" alt=" " class="download-button ">

        </div>
    </section>
    <section id=footer>
        <div class=" content-container ">
            <p>COPYRIGHT © 2018. ALL RIGHTS RESERVED. DESIGN BY TEAM NETWORK B</p>
        </div>
    </section>
    <script src="/assets/js/app-min.js "></script>
</body>
</html>
