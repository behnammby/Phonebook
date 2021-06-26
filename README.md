# Phonebook

This is a sample project that implements a simple phonebook as a RESTful API.

## RESTful API

### What is an API?

Every modern businesses must share data [1], but sharing data between contemporary sprawled systems is challenging. We we are to connect systems and share data we'll come up with the concept of system integration.
System integration is defined in engineering as the process of bringing together the component sub-systems into one system and ensuring that the subsystems function together as a system [2]. API is a tool for integration.
API stands for **A**pplication **P**rogramming **I**nterface and is a set of **definitions** and **protocols** for **building** and **integrating** application software. API let's your product or service communicate with other products and services without having to know how they're implemented [3].

### What is a RESTful API?

REST stands for Representational State Transfer. A REST API also known as a RESTful API, is an application programming interface that conforms to the constraints of **REST architectural style**. REST is a set of architectural constraints, not a protocol or a standard [4].

## Guiding principles of REST

**Client-Server** - By seperating the user interface concerns from the data storage concerns, we improve the portability of the user interface across multiple platforms and improve scalability by simplifying the server componenets.

**Stateless** - Each request from client to server must contain all of the information necessary to understand the request, and connot take advantage of any stored context on the server. Session state therefore kept entirely on the client.

**Cacheable** Cache constraints require that the data within a response to a request be implicitly or explicitly labeled as cacheable or non-cacheable. If a response is cacheable, the a client cache is given the right to reuse that response for later equivalent requests.

**Uniform Interface** - By applying the software engineering principle of generality to the component interface, the overall system architecture is simplified and the visibility of interactions is improved. In order to obtain a uniform interface, mutiple architectural constraints are needed to guide the behavior of componenets. REST is identified by four interface constraints: _identification of resources_; _manipulation of resources through representations_; _self-descriptive messages_; and, _hypermedia as the engine of application state_.

**Layered System** - The layered system style allows an architecture to be composed of hierarchical layers by contraining component behavior such that each component cannot "see" beyond the immediate layer with which they are interacting.

**Code on Demand** (optional) - REST allows client functionality to be executed by downloading and executing code in the form of applets or scripts. This simplifies clients by reducing the number of features required to be pre-implemented.

## Resources

[1] . <https://www.redhat.com/en/topics/integration>
[2] . <https://en.wikipedia.org/wiki/System_integration#cite_note-Heat-1>
[3] . <https://www.redhat.com/en/topics/api/what-are-application-programming-interfaces>
[4] . <https://www.redhat.com/en/topics/api/what-is-a-rest-api>

## Vocabulary

**Service** is a software or a piece of code, that performs a specific task or response to an event as per request and produce a specific output.
**Web Service** is a service available on the internet, that have standardized communication protocols and information exchange medium.
**Interface** is an edge or a boundary where two systems can meet and exchange information.
<https://www.youtube.com/watch?v=MvalT6>

**Communication protocol** is a system of rules that allows two or more entities of a communication system to transmit information via any kind of variation of a physical quantity.
<https://en.wikipedia.org/wiki/Communication_protocol>

**Stateless protocol** is a communication protocol on which the receiver must not retain session state from previous requests. The sender transfers relevant session state to the receiver in such a way that every request can be understood in isolation, that is without reference to session state from previous requests retained by the receiver. Examples of stateless protocols are IP and HTTP.
**Stateful protocol** is a communication protocol in which the reciever may retain session state from previous requests. Examples of stateful protocols are TCPand FTP.
<https://en.wikipedia.org/wiki/Stateless_protocol>

**Architectural pattern** is a general, reusable solution to a commonly occuring problem in software architecture within a given context.
<https://en.wikipedia.org/wiki/Architectural_pattern>

**Uniform Resource Locater (URI)** is a unique sequence of characters that identifies a logical or physical resource used by web technologies.
**Uniform Resource Name (URN)** is a URI that identifies a resource by name in a particular namespace. A URN may be used to talk about a resource without implying its location or how to access it.
**Uniform Resource Locator (URL)** is a URI that specifies the means of acting upon or obtaining the representation of a resource, i.e. specifying both its primary access mechanism and network location.
A URN may be compared to a person's name, while a URL may be compared to their street address. In other words, a URN identifies an item and a URL provides a method for finding it.
<https://en.wikipedia.org/wiki/Uniform_Resource_Identifier>

**Resource** is any information that can be referenced and have a name and a unique address or a path to it. REST uses a resource identifier to identify the particular resource involved in an interaction between components.
**Resource Representation** is the state of the resource at any particular timestamp. A representation consists of data, metadata describing the data and hypermedia links which can help the clients in transition to the next desired state.
<https://restfulapi.net>

**Representational State** is simply current state of an object.
<https://medium.com/future-vision/the-principles-of-rest-6b00deac91b3>
