<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="I3332_Project.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>Login</title>

    <!-- Bootstrap 5 CDN -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f8f9fa;
        }

        .login-container {
            max-width: 400px;
            margin: 80px auto;
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .form-label {
            font-weight: 600;
        }

        .form-control {
            border-radius: 5px;
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
            <div class="login-container">
                <h3 class="text-center mb-4">Login to Your Account</h3>

                <div class="mb-3">
                    <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" CssClass="form-label" Text="Username" />
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Password" />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>

                <div class="message text-center">
                    <asp:Label ID="lblMessage" runat="server" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS (optional if using components) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
