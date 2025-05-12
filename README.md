# Datastar and FastEndpoints example

## What is Datastar?

Datastar is a lightweight hypermedia framework that brings reactive functionality to server-rendered applications. It combines the best of both worlds:

 - The simplicity and reliability of server-side rendering
 - The dynamic, reactive user experience in the style of a Single Page Application (SPA) but with very little to no JavaScript

## Goals

 - [x] .NET 9 API with hot-reload
 - [x] Implement FastEndpoints
 - [x] Implement .liquid templates for UI

       ```Liquid was originally created by Shopify as a secure and customizable template language for web content. Designed to empower users to modify storefronts safely, it has since become widely adopted in various web frameworks and static site generators.```

 - [x] Implement Tailwind CSS for styling

       Currently using Tailwind CSS 4. `npm run dev` will start both `dotnet watch run` and the tailwind cli in watch mode.

 - [x] Implement Datastar
 - [ ] Authentication and authorization using Auth0
 - [ ] Redirect to Auth0 login page from endpoint

       If a endpoint is protected by authentication, the user will be redirected to the Auth0 login page. After successful login, the user will be redirected back to the original page.

 - [x] Anonymous routes
 - [x] 404 UI if endpoint is not found
 - [ ] Better error handling

### Future nice-to-haves
 - [x] Tailwind part of hot-reload

       When changes are made to the .liquid templates, the tailwind CSS is recompiled and hot-reloaded in the browser. This allows for a fast development experience without having to refresh the page.

 - [ ] Hot-reload FastEndpoints endpoints registration if path has changed
 - [ ] Navigation context inside .liquid templates
 - [x] Datastar SSE fragments using .liquid

       Could be valueable to have the navigation context inside the .liquid templates. This would allow for a more dynamic and reactive user experience.

 - [ ] Datastar SSE fragments using .liquid template inline?
 - [ ] Inline-.liquid code in FastEndpoints endpoint?
 - [ ] Look into best practices for FastEndpoints project structure
 - [ ] 404 UI endpoint should return a 404 status code

## This repository

While looking into dotnet and Datastar, I found that there were very few examples of using Datastar with FastEndpoints. So I decided to take a run at it. During the process I stumbled across a few useful repositories from other authors taking a run at implementing Datastar with dotnet in different UI frameworks.

### Other repositories

**"RickTheHat/DatastarExamples"**

Base for my repo is from his "DatastarExamples" repository. It is a collection of examples of using Datastar with different frameworks and languages. The examples are not all working, but they are a good starting point for learning how to use Datastar with different frameworks.

## References

- https://github.com/sebastienros/fluid/blob/main/MinimalApis.LiquidViews
- https://tailwindcss.com/docs/upgrade-guide#using-tailwind-cli
- https://flowbite.com/docs/getting-started/quickstart/#install-using-npm
- https://github.com/starfederation/datastar/tree/main/sdk/dotnet
- https://fast-endpoints.com/docs/server-sent-events