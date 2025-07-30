<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="I3332_Project.Signup" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>Signup</title>

    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- This line links to the Bootstrap 5.3.0 CSS file, which is hosted on jsDelivr, a free Content Delivery Network (CDN). -->
    
    <style>
        body {
            background-color: #f8f9fa;
        }

        .signup-container {
            max-width: 450px;
            margin: 80px auto;
            background-color: white;
            padding: 35px;
            border-radius: 10px;
            box-shadow: 0 0 12px rgba(0,0,0,0.1);
        }

        .btn-primary {
            width: 100%;
        }

        .message {
            margin-top: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="signup-container">
                <h3 class="text-center mb-4">Create an Account</h3>

                <!-- Message for signup success or failure -->
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="text-center message" /><br />

                <!-- Username -->
                <div class="mb-3">
                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" CssClass="form-control" />
                </div>

                <!-- Email -->
                <div class="mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" TextMode="Email" />
                </div>

                <!-- Password -->
                <div class="mb-3">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" CssClass="form-control" />
                </div>

                <!-- Signup Button -->
                <div class="d-grid">
                    <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignup_Click" />
                </div>

                <!-- Link to Login page if user already has an account -->
                <div class="text-center mt-3">
                    <asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="Login.aspx">Already have an account? Login here.</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS (optional if you need JavaScript components) -->
  <!--  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>-->
</body>
</html>
